﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour, IWeapon
{

    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Camera currentCamera;
    [SerializeField] private float offsetBullet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Vector3 cursorPos = currentCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = cursorPos - transform.position;
        direction.z = 0;
        direction = direction.normalized;

        Debug.Log(direction);

        Vector3 initPosBullet = transform.position + offsetBullet * direction;
        Bullet bullet = Instantiate(bulletObject, initPosBullet, transform.rotation).GetComponent<Bullet>();
        bullet.Init(initPosBullet, direction);
    }

    public bool CanShoot()
    {
        return Input.GetMouseButtonDown(0);
    }
}
