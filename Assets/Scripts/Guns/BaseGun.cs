using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseGun
{
   public int currentMagazineSize;
   
   protected int magazineSize;
   protected float reloadTime;
   protected float nextFireTime;
   protected float fireRate;
   protected bool isRedyToShoot = true;
   protected bool isReloading;
   
   protected GameObject bulletPrefab;
   protected GameObject gunPrefab;
   protected Transform firePoint;
  
   


   public BaseGun(int magazineSize, float reloadTime, float fireRate, GameObject bulletPrefab, GameObject gunPrefab)
   {
      this.magazineSize = magazineSize;
      this.fireRate = fireRate;
      this.reloadTime = reloadTime;
      this.bulletPrefab = bulletPrefab;
      firePoint = gunPrefab.transform.Find("firePoint");
      // Debug.Log(firePoint.transform.position);
      currentMagazineSize = this.magazineSize;
   }
   public abstract void Shoot();

   public void ChangeAmmo(int val)
   {
      currentMagazineSize += val;
      if (currentMagazineSize <= 0)
      {
         Reload();
      }
   }
   public async void Reload()
   {
      if (currentMagazineSize < magazineSize && !isReloading)
      {
         isReloading = true;
         isRedyToShoot = false;
         
         await Task.Delay((int) (reloadTime * 1000));
         currentMagazineSize = magazineSize;
         
         isReloading = false;
         isRedyToShoot = true;
         
      }
   }
   
   public void Update()
   {
      
      
   }

   
}
