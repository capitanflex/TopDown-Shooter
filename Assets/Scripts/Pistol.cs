

using UnityEngine;

public class Pistol : BaseGun
{
    public Pistol(int magazineSize, float reloadTime, float fireRate, GameObject bulletPrefab) : base(magazineSize, reloadTime, fireRate, bulletPrefab) {}
    
    public override void Shoot()
    {
        
        if (Time.time >= nextFireTime && currentMagazineSize > 0 && isRedyToShoot)
        {
            nextFireTime = Time.time + fireRate;
            currentMagazineSize--;
            
            GameObject.Instantiate(bulletPrefab);
            
            Debug.Log(currentMagazineSize);
            
        }
         
    }
    
}
