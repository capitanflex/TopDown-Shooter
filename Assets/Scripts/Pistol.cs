using UnityEngine;

public class Pistol : BaseGun
{
    public Pistol(int magazineSize, float reloadTime, float fireRate, GameObject bulletPrefab, GameObject gunPrefab) : base(magazineSize, 
        reloadTime, fireRate, bulletPrefab, gunPrefab) {}
    
    public override void Shoot()
    {
        
        if (Time.time >= nextFireTime && currentMagazineSize > 0 && isRedyToShoot)
        {
            nextFireTime = Time.time + fireRate;
            ChangeAmmo(-1);
            
            GameObject.Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        }
         
    }
    
}
