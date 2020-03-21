using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Camera currentCamera;
    [SerializeField] private float offsetBullet;

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
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
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
}