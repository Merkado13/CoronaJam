using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponEntry : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite selectedSpr;
    [SerializeField] private Sprite deselectedSpr;
    [SerializeField] private Sprite unavailableSpr;

    [Header("Connections")]
    [SerializeField] private Text priceText;
    [SerializeField] private Text weaponText;
    [SerializeField] private Image entrySprite;
    [SerializeField] private Text descriptionText;
    
    private Image showcaseImage;

    private WeaponInfo weaponInfo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(WeaponInfo wi, Image showcaseImage, Text descriptionText)
    {
        weaponInfo = wi;
        weaponText.text = wi.name;
        priceText.text = wi.price.ToString();
        this.showcaseImage = showcaseImage;
        this.descriptionText = descriptionText;
    }

    public void Selected()
    {
        showcaseImage.sprite = weaponInfo.sprite;
        descriptionText.text = weaponInfo.description;
        entrySprite.sprite = selectedSpr;
    }

    public void Deselected()
    {
        entrySprite.sprite = deselectedSpr;
    }
}
