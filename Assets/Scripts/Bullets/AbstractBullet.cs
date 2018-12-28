using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets;

public class AbstractBullet : MonoBehaviour {

    protected AbstractDeveloper dev;
    public float speed;
    public GameObject bulletHit;
    
    void Update()
    {
        if(dev.Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = dev.Target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceFrame)
        {
            HitEnemy();
            return;
        }

        transform.Translate(direction.normalized * distanceFrame, Space.World);
    }

    public void Init(AbstractDeveloper dev)
    {
        this.dev = dev;
    }

    private void HitEnemy()
    {
        var bug = dev.Target.GetComponent<AbstractBug>();
        if (bug != null)
        {
            if (dev.attacks != null)
            {
                foreach (var attack in dev.attacks)
                {
                    attack.Attack(dev);
                }
            }
        }

        GameObject bulletHitEffect = Instantiate(bulletHit, transform.position, transform.rotation);
        Destroy(bulletHitEffect, 2f);

        Destroy(gameObject);
    }
}
