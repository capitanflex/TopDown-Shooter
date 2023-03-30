using System.Collections;
using System.Collections.Generic;
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
   
   protected GameObject bulletPrefab;
  
   


   public BaseGun(int magazineSize, float reloadTime, float fireRate, GameObject bulletPrefab)
   {
      this.magazineSize = magazineSize;
      this.fireRate = fireRate;
      this.reloadTime = reloadTime;
      this.bulletPrefab = bulletPrefab;
      currentMagazineSize = this.magazineSize;
   }
   public abstract void Shoot();


   public async void Reload()
   {
      if (currentMagazineSize < magazineSize)
      {
         isRedyToShoot = false;
         await Task.Delay((int) (reloadTime * 1000));
         currentMagazineSize = magazineSize;
         isRedyToShoot = true;
      }
   }
   
   public void Update()
   {
      

      
   }

   
}
