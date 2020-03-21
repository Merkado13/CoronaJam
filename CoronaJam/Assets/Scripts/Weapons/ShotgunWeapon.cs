﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Camera currentCamera;
    [SerializeField] private float offsetBullet;
    [SerializeField] private float cadency;
    [SerializeField] private AudioSource shotSound;
    [SerializeField] private float yOffset = 0;

    private float lastTimeShot = 0;

    private WeaponInfoPlay weaponInfo;
    private SpriteRenderer renderer;
    private LookingAtCursor lookat;
    private Hideable hideable;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        lookat = GetComponent<LookingAtCursor>();
        hideable = GetComponent<Hideable>();
        weaponInfo = GetComponent<WeaponInfoPlay>();
        currentCamera = Camera.main;
    }

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
        Bullet bullet = Instantiate(bulletObject,
            initPosBullet + new Vector3(0, yOffset, 0), transform.rotation).GetComponent<Bullet>();
        bullet.Init(initPosBullet, direction);

        weaponInfo.currentAmmo = (int.Parse(weaponInfo.currentAmmo) - 1).ToString();

        if (shotSound != null)
        {
            if (!shotSound.isPlaying)
                shotSound.Play();
        }
    }

    public bool CanShoot()
    {
        int ammo = int.Parse(weaponInfo.currentAmmo);

        if (lastTimeShot + 1 / cadency < Time.time && ammo > 0 && Input.GetMouseButton(0))
        {
            lastTimeShot = Time.time;
            return true;
        }
        return false;
    }

    public void Init()
    {
        LookingAtCursor lookAt = GetComponent<LookingAtCursor>();
        lookAt.setCamera(currentCamera);
    }

    public void Hide()
    {
        hideable.Hide();
    }

    public void Show()
    {
        hideable.Show();
    }

    public WeaponInfoPlay GetWeaponData()
    {
        return weaponInfo;
    }


    public void Reload(int ammo)
    {
        int muni;
        bool canParse = int.TryParse(weaponInfo.currentAmmo, out muni);
        if (canParse)
        {
            int max = int.Parse(weaponInfo.maxAmmo);
            weaponInfo.currentAmmo = Mathf.Clamp(muni + ammo, 0, max).ToString();
        }
    }
}
