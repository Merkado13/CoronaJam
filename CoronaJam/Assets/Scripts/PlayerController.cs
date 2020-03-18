using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject weaponObject;
    public IWeapon weapon { get; set; }

    [SerializeField] private bool canLockWindow;
    [SerializeField] private bool canWashHands;

    // Start is called before the first frame update
    void Start()
    {
        weapon = weaponObject.GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            trigger.perform(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ITrigger trigger = collision.GetComponent<ITrigger>();
        if(trigger != null)
        {
            trigger.deperform(this);
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

    public bool getCanWashHands()
    {
        return canWashHands;
    }

    public void setCanWashHands(bool canWashHands)
    {
        this.canWashHands = canWashHands;
    }
    #endregion
}
