using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weapons { MANUAL, RAFAGE, AUTOMATIC, MINIGUN, GRANADER, SHOTGUN}

public interface IWeapon
{
    void Shoot();
    bool CanShoot();
    void Hide();
    void Show();
}
