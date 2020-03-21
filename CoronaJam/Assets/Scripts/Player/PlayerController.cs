using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float ENEMY_SPEED_MULTIPLIER = 1.0f;
    public static float DAMAGE_MULTIPLIER = 1.0f;

    [SerializeField] private GameObject weaponObject;
    public List<IWeapon> weapons = new List<IWeapon>();
    public IWeapon currentWeapon { get; set; }

    [SerializeField] private bool canLockWindow;
    [SerializeField] private bool canCraft;
    [SerializeField] private bool canWashHands;

    public bool isWashingHands { get; set; }
    public bool isCrafting { get; set; }
    public bool isLockingWindow { get; set; }

    private ITrigger currentZone;
    private int currentWeaponIndex = 0;

    readonly public static float MAX_CLEAN = 100.0f;
    [SerializeField] private float cleaness = MAX_CLEAN;
    [SerializeField] private int gearsCount = 0;
    [SerializeField] private GUIController guiController;

    private LiquidSoap liquid;
    private Pill pill;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = weaponObject.GetComponent<IWeapon>();
        weapons.Add(currentWeapon);
        InitGUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U)){
            setCleaness(getCleaness() - 1.2f);
        }
        if (Input.GetKey(KeyCode.I))
        {
            setGearsCount(getGearsCount() + 1000);
        }

        guiController.UpdateWeapon(currentWeapon);
    }

    private void InitGUI()
    {
        guiController.UpdateGears(gearsCount);
        guiController.UpdateCleaness(MAX_CLEAN);
        guiController.UpdateLiquidSoap(false);
        guiController.UpdatePill(false, ColorPill.RED);
        guiController.UpdateWeapon(currentWeapon);
    }

    public void UpdateWeponInfo()
    {
        guiController.UpdateWeapon(currentWeapon);
    }

    public bool isDead()
    {
        return cleaness <= 0;
    }

    public void Shoot()
    {
        if (currentWeapon != null)
        {
            if (currentWeapon.CanShoot())
            {
                currentWeapon.Shoot();
            }
        }
    }

    public void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.Q) && pill != null)
        {
            pill.UsePill(this);
            pill = null;
            guiController.UpdatePill(false, ColorPill.RED);
        }

        if (Input.GetKeyDown(KeyCode.E) && liquid != null)
        {
            liquid.UseLiquidSoap(this);
            liquid = null;
            guiController.UpdateLiquidSoap(false);
        }
    }

    public void ChangeBtwWeapons()
    {
        bool goUp = Input.GetKeyDown(KeyCode.Z) || Input.GetAxis("Mouse ScrollWheel") > 0f;
        bool goDown = Input.GetKeyDown(KeyCode.X) || Input.GetAxis("Mouse ScrollWheel") < 0f;
        if (goUp)
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            SwapWeapon(weapons[currentWeaponIndex]);
        }
        else if (goDown)
        {
          
            currentWeaponIndex = currentWeaponIndex <= 0 ? weapons.Count - 1 : currentWeaponIndex - 1;
            SwapWeapon(weapons[currentWeaponIndex]);
        }    
    }

    public void PrepareIncomingWeapon(GameObject weaponPurchased)
    {
        IWeapon weapon = weaponPurchased.GetComponent<IWeapon>();
        weapon.Init();
        weapons.Add(weapon);
        currentWeaponIndex = weapons.Count - 1;
        SwapWeapon(weapon);
    }

    private void SwapWeapon(IWeapon weaponToSwap)
    {
        currentWeapon.Hide();
        guiController.UpdateWeapon(weaponToSwap);
        currentWeapon = weaponToSwap;
        currentWeapon.Show();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITrigger trigger = collision.GetComponent<ITrigger>();
        if (trigger != null)
        {
            trigger.Enter(this);
            currentZone = trigger;
        }
        IPickable pickable = collision.GetComponent<IPickable>();
        if(pickable != null)
        {
            pickable.Pick(this);
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

    public IEnumerator SlowEnemies(float effectMultiplier, float effectTime)
    {
        ENEMY_SPEED_MULTIPLIER = effectMultiplier;
        yield return new WaitForSeconds(effectTime);
        ENEMY_SPEED_MULTIPLIER = 1.0f;
    }

    public IEnumerator UpgradeDamage(float effectMultiplier, float effectTime)
    {
        DAMAGE_MULTIPLIER = effectMultiplier;
        yield return new WaitForSeconds(effectTime);
        DAMAGE_MULTIPLIER = 1.0f;
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
        this.cleaness = Mathf.Clamp(cleaness,0,MAX_CLEAN);
        guiController.UpdateCleaness(this.cleaness);
    }

    public int getGearsCount()
    {
        return gearsCount;
    }

    public void setGearsCount(int gearsCount)
    {
        this.gearsCount = gearsCount;
        guiController.UpdateGears(this.gearsCount);
    }

    public Pill getPill()
    {
        return pill;
    }

    public bool setPill(Pill pill)
    {
        if (this.pill == null)
        {
            this.pill = pill;
            guiController.UpdatePill(true, pill.color);
            return true;
        }
        return false;
    }

    public LiquidSoap getLiquidSoap()
    {
        return liquid;
    }

    public bool setLiquidSoap(LiquidSoap liquid)
    {
        if (this.liquid == null)
        {
            this.liquid = liquid;
            guiController.UpdateLiquidSoap(true);
            return true;
        }

        return false;
    }

    public GUIController GetGUIController()
    {
        return guiController;
    }

    #endregion
}
