using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPick : MonoBehaviour, IPickable
{
    [SerializeField] int ammoAmount;

    public void Pick(PlayerController player)
    {
        player.currentWeapon.Reload(ammoAmount);
        Destroy(gameObject);
    }
}
