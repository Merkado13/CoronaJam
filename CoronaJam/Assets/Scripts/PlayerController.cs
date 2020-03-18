using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject weaponObject;
    private IWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = weaponObject.GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon.CanShoot())
        {
            weapon.Shoot();
        }
    }
}
