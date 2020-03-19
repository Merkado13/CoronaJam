using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class EnemyHealth : MonoBehaviour
{
    #region variables

    [SerializeField] private float health;
    [SerializeField] private float timeToDisappear;

    private Animator enemyFSM;
    private SAP2D.SAP2DAgent navAgent;

    #endregion variables

    private void Start()
    {
        enemyFSM = GetComponent<Animator>();
        navAgent = GetComponent<SAP2D.SAP2DAgent>();
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        if(health <= 0) {
            enemyFSM.SetBool("isDead", true);
        }
    }

    [StateEnterMethod("Base.Dead")]
    public void Dead()
    {
        if(transform.childCount > 0) {
            transform.GetChild(0).parent = null;
            navAgent.CanMove = false;
        }
        Destroy(gameObject, timeToDisappear);
    }
}