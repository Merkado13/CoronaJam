using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weapons { MANUAL, RAFAGE, MINIGUN, SHOTGUN}

public interface IWeapon
{
    void Init();
    void Shoot();
    bool CanShoot();
    void Hide();
    void Show();
    void Reload(int ammount);
    WeaponInfoPlay GetWeaponData();
}
