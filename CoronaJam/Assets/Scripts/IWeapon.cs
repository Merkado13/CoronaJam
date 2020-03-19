using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weapons { MANUAL, SEMI_AUTOMATIC, AUTOMATIC, MINIGUN, GRANADER}

public interface IWeapon
{
    void Shoot();
    bool CanShoot();
    void Hide();
    void Show();
}
