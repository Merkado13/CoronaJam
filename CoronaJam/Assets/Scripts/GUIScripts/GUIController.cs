using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField] private Text gearsText;
    [SerializeField] private RectTransform soapBarMask;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Text ammoText;
    [SerializeField] private Image pillImage;
    [SerializeField] private Image liquidSoapImage;

    [SerializeField] private Sprite bluePill;
    [SerializeField] private Sprite redPill;

    private readonly Color WHITE = new Color(255, 255, 255, 255);
    private readonly Color ALPHA = new Color(255, 255, 255, 0);

    public void UpdateGears(int gears)
    {
        gearsText.text = gears.ToString();
    }

    public void UpdateCleaness(float cleaness)
    {
        soapBarMask.sizeDelta = new Vector2(cleaness, soapBarMask.rect.height);
    }

    public void UpdateWeapon(IWeapon weapon)
    {
        WeaponInfoPlay info = weapon.GetWeaponData();
        weaponImage.sprite = info.sprWeaponGUI;
        weaponImage.rectTransform.sizeDelta = new Vector2(info.sprWeaponGUI.rect.width,
            info.sprWeaponGUI.rect.height) * 3;
        ammoText.text = info.currentAmmo + "/" + info.maxAmmo;
    }

    public void UpdatePill(bool available, ColorPill color)
    {
        pillImage.color = available ? WHITE : ALPHA;
        if (color == ColorPill.BLUE) {
            pillImage.sprite = bluePill;
        }else if(color == ColorPill.RED)
        {
            pillImage.sprite = redPill;
        }
    }

    public void UpdateLiquidSoap(bool available)
    {
        liquidSoapImage.color = available ? WHITE : ALPHA;
    }

}
