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
    private bool[] isWeaponPurchased;
    [SerializeField] private GameObject weaponEntryObject;
    private WeaponEntry weaponEntry;
    private readonly int MAX_NUM_WEAPONS = System.Enum.GetNames(typeof(Weapons)).Length;

    [SerializeField] private Image showcaseImage;
    [SerializeField] private Text textDesription;
    [SerializeField] private float heightEntry = 43;
    [SerializeField] private float offsetBtwEntry = 40;
    [SerializeField] private WeaponInfo[] weaponsInfo;

    private int numOfEntriesPerStep = 3;
    private int currentStep = 0;
    private int maxStep;
    private int minStep = 0;
    private float steppingOffset;

    public enum Direction { UP = -1, DOWN = 1 }

    

    private void Awake()
    {
        weaponEntry = weaponEntryObject.GetComponent<WeaponEntry>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isWeaponPurchased = new bool[MAX_NUM_WEAPONS];
        maxStep = (MAX_NUM_WEAPONS - 1) / numOfEntriesPerStep;
        steppingOffset = (heightEntry + offsetBtwEntry) * numOfEntriesPerStep;
        CreateWeaponEntries();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        for(int i = 0; i < MAX_NUM_WEAPONS; i++)
        {
            GameObject entryObject = Instantiate(weaponEntryObject, 
                transform.position + new Vector3(0,-1,0) * (i * heightEntry + i * offsetBtwEntry), 
                transform.rotation,transform);

            WeaponEntry entry = entryObject.GetComponent<WeaponEntry>();
            entry.Init(weaponsInfo[i], showcaseImage, textDesription);
        }
    }

    private void ShowNotPurchasedWeapons()
    {
        
    }
}
