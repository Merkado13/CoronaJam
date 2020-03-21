using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafageWeapon : MonoBehaviour, IWeapon
{

    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Camera currentCamera;
    [SerializeField] private float offsetBullet;
    [SerializeField] private float cadency;
    [SerializeField] private AudioSource shotSound;
    [SerializeField] private float yOffset = 0;

    private WeaponInfoPlay weaponInfo;
    private SpriteRenderer renderer;
    private LookingAtCursor lookat;
    private Hideable hideable;

    [SerializeField] private int bulletsPerRafage = 3;
    [SerializeField] private float timeBtwBullets = 0.1f;
    private float lastTimeShot = 0;

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
        StartCoroutine("RafageShot");
    }

    IEnumerator RafageShot()
    {     
        for (int i = 0; i < bulletsPerRafage; i++)
        {
            int ammo = int.Parse(weaponInfo.currentAmmo);

            if (ammo > 0)
            {
                Vector3 cursorPos = currentCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction = cursorPos - transform.position;
                direction.z = 0;
                direction = direction.normalized;

                Vector3 initPosBullet = transform.position + offsetBullet * direction;

                Bullet bullet = Instantiate(bulletObject,
                    initPosBullet + new Vector3(0, yOffset, 0), transform.rotation).GetComponent<Bullet>();
                bullet.Init(initPosBullet, direction);

                weaponInfo.currentAmmo = (ammo - 1).ToString();

                yield return new WaitForSeconds(timeBtwBullets);
            }
        }
    }

    public bool CanShoot()
    {
        if (lastTimeShot + 1 / cadency < Time.time && Input.GetMouseButtonDown(0))
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
