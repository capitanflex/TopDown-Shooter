using UnityEngine;

public class AutomaticGun : BaseGun
{
    public AutomaticGun(int magazineSize, float reloadTime, float fireRate, GameObject bulletPrefab,  GameObject gunPrefab) : base(magazineSize, 
        reloadTime, fireRate, bulletPrefab,  gunPrefab) {}

    public override void Shoot()
    {
        if (Time.time >= nextFireTime && currentMagazineSize > 0 && isRedyToShoot)
        {
            nextFireTime = Time.time + fireRate;
            ChangeAmmo(-1);
            
            GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            
            
        }
    }
}

