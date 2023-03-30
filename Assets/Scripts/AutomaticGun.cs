using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : BaseGun
{
    public AutomaticGun(int magazineSize, float reloadTime, float fireRate, GameObject bulletPrefab, Transform firePoint) : base(magazineSize, 
        reloadTime, fireRate, bulletPrefab, firePoint) {}

    public override void Shoot()
    {
        if (Time.time >= nextFireTime && currentMagazineSize > 0 && isRedyToShoot)
        {
            nextFireTime = Time.time + fireRate;
            ChangeAmmo(-1);
            
            GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            Debug.Log(currentMagazineSize);
            
        }
    }
}

