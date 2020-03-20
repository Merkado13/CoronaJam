using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponInfo
{
    public string name;
    public string description;
    public int price;
    public Sprite sprite;
}

public class ArrayWeaponEntry : MonoBehaviour
{
   
    [SerializeField] private GameObject weaponEntryObject;
    [SerializeField] private GameObject[] weaponsGame;
    private WeaponEntry weaponEntry;
    private static readonly int MAX_NUM_WEAPONS = System.Enum.GetNames(typeof(Weapons)).Length;

    private bool[] isWeaponPurchased;
    private WeaponEntry[] entries; 

    [SerializeField] private Image showcaseImage;
    [SerializeField] private Text textDesription;
    [SerializeField] private float heightEntry = 43;
    [SerializeField] private float offsetBtwEntry = 40;
    [SerializeField] private WeaponInfo[] weaponsInfo;

    [SerializeField] private  PlayerController player;

    private int numOfEntriesPerStep = 3;
    private int currentStep = 0;
    private int maxStep;
    private int minStep = 0;
    private float steppingOffset;

    public enum Direction { UP = -1, DOWN = 1 }

    private bool created = false;
    private int currentNumOfWeapons;

    private Vector3 originPos;

    private void Awake()
    {
        weaponEntry = weaponEntryObject.GetComponent<WeaponEntry>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        if(!created)
            CreateWeaponEntries();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CalculateMaxStep()
    {
        maxStep = (currentNumOfWeapons - 1) / numOfEntriesPerStep;
    }   

    public void Move(int dir)
    {
        if (dir == (int)Direction.UP) {
            if (currentStep-1 >= minStep)
            {
                currentStep--;
                transform.Translate(new Vector3(0,dir,0) * steppingOffset);
            }
        }else if (dir == (int)Direction.DOWN)
        {
            if(currentStep+1 <= maxStep)
            {
                currentStep++;
                transform.Translate( new Vector3(0, dir, 0) * steppingOffset);
            }
        }
    }


    private void CreateWeaponEntries()
    {
        originPos = transform.position;
        currentNumOfWeapons = MAX_NUM_WEAPONS;
        isWeaponPurchased = new bool[MAX_NUM_WEAPONS];
        entries = new WeaponEntry[MAX_NUM_WEAPONS];
        CalculateMaxStep();
        steppingOffset = (heightEntry + offsetBtwEntry) * numOfEntriesPerStep;

        for (int i = 0; i < MAX_NUM_WEAPONS; i++)
        {
            GameObject entryObject = Instantiate(weaponEntryObject, 
                transform.position + new Vector3(0,-1,0) * (i * heightEntry + i * offsetBtwEntry), 
                transform.rotation,transform);

            entries[i] = entryObject.GetComponent<WeaponEntry>();
            entries[i].Init(i, weaponsInfo[i], showcaseImage, textDesription, player);
        }

        created = true;
    }

    public void Purchase(int index)
    {
        isWeaponPurchased[index] = true;
        GameObject weaponPurchased = Instantiate(weaponsGame[index], player.transform);
        player.PrepareIncomingWeapon(weaponPurchased);
       
    }

    public void ShowNotPurchasedWeapons()
    {
        if (!created)
        {
            CreateWeaponEntries();
        }
        currentStep = 0;
        transform.position = originPos;
        int numOfNotWeaponPurchased = 0;
        for(int i = 0; i < isWeaponPurchased.Length; i++)
        { 
            if (isWeaponPurchased[i])
            {
                if (entries[i] != null)
                {
                    Destroy(entries[i].gameObject);
                    currentNumOfWeapons--;
                }
            }
            else
            {
                entries[i].transform.position = transform.position + 
                     new Vector3(0, -1, 0) * numOfNotWeaponPurchased * (heightEntry + offsetBtwEntry);
                numOfNotWeaponPurchased++;
                
            }
        }

        CalculateMaxStep();
    }
}
