using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private BaseGun _baseGun;
    void Start()
    {
        // _baseGun = new Pistol(10, 2,0.5f , bulletPrefab, firePoint);
        _baseGun = new AutomaticGun(30, 2.5f,0.05f , bulletPrefab, firePoint);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _baseGun.currentMagazineSize > 0)
        {
            _baseGun.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _baseGun.Reload();
        }
        _baseGun.Update();
        ChangeGun();
    }

    private void ChangeGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _baseGun = new Pistol(10, 2,0.5f , bulletPrefab, firePoint);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _baseGun = new AutomaticGun(30, 2.5f,0.05f , bulletPrefab, firePoint);
        }
    }
    
}
