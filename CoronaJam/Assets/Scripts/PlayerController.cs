using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject weaponObject;
    public IWeapon weapon { get; set; }

    [SerializeField] private bool canLockWindow;
    [SerializeField] private bool canCraft;
    [SerializeField] private bool canWashHands;

    public bool isWashingHands { get; set; }
    public bool isCrafting { get; set; }
    public bool isLockingWindow { get; set; }

    private ITrigger currentZone;
    readonly public static float MAX_CLEAN = 100.0f;
    [SerializeField] private float cleaness = MAX_CLEAN;

    // Start is called before the first frame update
    void Start()
    {
        weapon = weaponObject.GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isDead()
    {
        return cleaness <= 0;
    }

    public void Shoot()
    {
        if (weapon.CanShoot())
        {
            weapon.Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITrigger trigger = collision.GetComponent<ITrigger>();
        if (trigger != null)
        {
            trigger.Enter(this);
            currentZone = trigger;
        }
    }

    public void PerformInZone()
    {
        if (currentZone != null)
        {
            if (Input.GetKey(KeyCode.E) && currentZone.CanPerform(this))
            {
                currentZone.Perform(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ITrigger trigger = collision.GetComponent<ITrigger>();
        if (trigger != null)
        {
            trigger.Exit(this);
            currentZone = null;
        }
    }


    #region getters_and_setters
    public bool getCanLockWindow()
    {
        return canLockWindow;
    }

    public void setCanLockWindow(bool canLockWindow)
    {
        this.canLockWindow = canLockWindow;
    }

    public bool getCanCraft()
    {
        return canCraft;
    }

    public void setCanCraft(bool canCraft)
    {
        this.canCraft = canCraft;
    }

    public bool getCanWashHands()
    {
        return canWashHands;
    }

    public void setCanWashHands(bool canWashHands)
    {
        this.canWashHands = canWashHands;
    }

    public float getCleaness()
    {
        return cleaness;
    }

    public void setCleaness(float cleaness)
    {
        this.cleaness = cleaness;
    }
    #endregion
}
