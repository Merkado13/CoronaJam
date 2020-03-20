using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingZone : MonoBehaviour, ITrigger
{
    [SerializeField] private GameObject craftingPanelGUI;
    [SerializeField] private ArrayWeaponEntry weaponEntries;

    public bool CanPerform(PlayerController player)
    {
        return true;
    }

    public void Enter(PlayerController player)
    {
        Debug.Log("He entrado en el crafting");
        player.setCanCraft(true);
    }

    public void Exit(PlayerController player)
    {
        Debug.Log("He salido del crafting");
        player.setCanCraft(false);
    }

    public void Perform(PlayerController player)
    {
        player.isCrafting = true;
        craftingPanelGUI.SetActive(true);
        weaponEntries.ShowNotPurchasedWeapons();
    }
}
