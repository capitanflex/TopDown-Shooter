using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : BaseGun
{
    public AutomaticGun(int magazineSize, float reloadTime, float fireRate, GameObject bulletPrefab) : base(magazineSize, reloadTime, fireRate, bulletPrefab)
    {
    }

    public override void Shoot()
    {
        throw new System.NotImplementedException();
    }
}

