using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Scripts;

public class ShootingBugs : MonoBehaviour, IShoot<AbstractDeveloper>
{
    public AbstractBullet bulletPrefab;
    private AbstractDeveloper dev;

    public void Shoot(AbstractDeveloper dev)
    {
        if (dev == null)
            return;

        this.dev = dev;
        if(dev.FireCountdown <= 0f)
        {
            FireBullet();            
            dev.FireCountdown = 1f / dev.FireRate;
        }

        dev.FireCountdown -= Time.deltaTime;
    }

    private void FireBullet()
    {
        var bulletGO = Instantiate(bulletPrefab, dev.bulletFirePosition.position, dev.bulletFirePosition.rotation);

        if (bulletGO != null)
            bulletGO.Init(dev);
    }
}
