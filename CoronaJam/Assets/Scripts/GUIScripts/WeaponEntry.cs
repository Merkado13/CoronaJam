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

    [SerializeField] private Sprite buttonCanBuySpr;
    [SerializeField] private Sprite buttonCanNotBuySpr;

    [Header("Connections")]
    [SerializeField] private Button priceButton;
    [SerializeField] private Text priceText;
    [SerializeField] private Text weaponText;
    [SerializeField] private Image entrySprite;
    [SerializeField] private Text descriptionText;
    
    private Image showcaseImage;
    private PlayerController player;
    private WeaponInfo weaponInfo;

    private bool canPurchase = false;
    private bool isSelected = false;
    private bool isPurchased = false;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canPurchase = player.getGearsCount() >= int.Parse(priceText.text);

        priceButton.enabled = canPurchase && !isPurchased;

        if (canPurchase && !isPurchased)
        {
            priceButton.image.sprite = buttonCanBuySpr;
            if(!isSelected)
                entrySprite.sprite = deselectedSpr;
            else
                entrySprite.sprite = selectedSpr;
        }
        else{
            priceButton.image.sprite = buttonCanNotBuySpr;
            entrySprite.sprite = unavailableSpr;
        }
    }

    public void Init(int index,WeaponInfo wi, Image showcaseImage, Text descriptionText, PlayerController player)
    {
        this.index = index;
        weaponInfo = wi;
        weaponText.text = wi.name;
        priceText.text = wi.price.ToString();
        this.showcaseImage = showcaseImage;
        this.descriptionText = descriptionText;
        this.player = player;
    }

    public void Purchase()
    {
        Debug.Log("comprado");
        isPurchased = true;
        player.setGearsCount(player.getGearsCount() - int.Parse(priceText.text));
        ArrayWeaponEntry arrayEntry = GetComponentInParent<ArrayWeaponEntry>();
        arrayEntry.Purchase(index);
    }

    public void Selected()
    {
        showcaseImage.sprite = weaponInfo.sprite;
        showcaseImage.rectTransform.sizeDelta = new Vector2(weaponInfo.sprite.rect.width,
            weaponInfo.sprite.rect.height) * 3;
        descriptionText.text = weaponInfo.description;
        isSelected = true;
    }

    public void Deselected()
    {
        isSelected = false;
    }
}
