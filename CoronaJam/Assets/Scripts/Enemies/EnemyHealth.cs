using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class EnemyHealth : MonoBehaviour
{
    #region variables

    public RoundController RoundController { get; set; }
    public GameObject Gear { get; set; }
    public GameObject Ammo { get; set; }
    public GameObject LiquidSoap { get; set; }
    public GameObject BluePill { get; set; }
    public GameObject RedPill { get; set; }

    [SerializeField] private float health;
    [SerializeField] private float timeToDisappear;
    [SerializeField] private float knockbackMultiplier;
    [SerializeField] private float knockbackLength;
    [Range(0, 1)] [SerializeField] private float gearDropRate;
    [Range(0, 1)] [SerializeField] private float ammoDropRate;
    [Range(0, 1)] [SerializeField] private float nothingDropRate;
    [Range(0, 1)] [SerializeField] private float pillsDropRate;

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

    public void MultiplyHealth(float multiplier)
    {
        health *= multiplier;
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

    private void OnDestroy()
    {
        float randomRate = Random.value;

        if(randomRate <= gearDropRate) {
            Instantiate(Gear, transform.position, transform.rotation);
        }
        else if(randomRate > gearDropRate && randomRate <= nothingDropRate) {
            if(Random.value < 0.5) {
                Instantiate(Ammo, transform.position, transform.rotation);
            }
            else {
                Instantiate(LiquidSoap, transform.position, transform.rotation);
            }
        }
        else if(randomRate >= pillsDropRate) {
            if(Random.value < 0.5) {
                Instantiate(BluePill, transform.position, transform.rotation);
            }
            else {
                Instantiate(RedPill, transform.position, transform.rotation);
            }
        }
    }
}