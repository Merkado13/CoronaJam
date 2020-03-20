using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class EnemyHealth : MonoBehaviour
{
    #region variables

    public RoundController RoundController { get; set; }

    [SerializeField] private float health;
    [SerializeField] private float timeToDisappear;
    [SerializeField] private float knockbackMultiplier;
    [SerializeField] private float knockbackLength;

    private Animator enemyFSM;
    private SAP2D.SAP2DAgent navAgent;
    private Rigidbody2D rigidbody;
    private bool isKnocked;
    private float knockbackCount;

    #endregion variables

    private void Start()
    {
        enemyFSM = GetComponent<Animator>();
        navAgent = GetComponent<SAP2D.SAP2DAgent>();
        rigidbody = GetComponent<Rigidbody2D>();
        knockbackCount = 0;
        isKnocked = false;
    }

    private void Update()
    {
        if(isKnocked) {
            knockbackCount += 0.1f;

            if(knockbackCount > knockbackLength) {
                rigidbody.velocity = Vector2.zero;
                knockbackCount = 0;
                isKnocked = false;
            }
        }
    }

    public void ReceiveDamage(float damage, Vector2 bulletDirection)
    {
        health -= damage;
        rigidbody.AddForce(bulletDirection * knockbackMultiplier, ForceMode2D.Impulse);
        isKnocked = true;

        if(health <= 0) {
            enemyFSM.SetBool("isDead", true);
        }
    }

    [StateEnterMethod("Base.Dead")]
    public void Dead()
    {
        if(transform.childCount > 0) { // The enemy has the toilet paper
            transform.GetChild(0).parent = null;
        }

        RoundController.EnemyKilled();
        navAgent.CanMove = false;
        Destroy(gameObject, timeToDisappear);
    }
}