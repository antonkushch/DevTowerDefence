using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interfaces;
using System.Collections;

namespace Assets.Scripts
{
    public class ShortestDistanceBugDetermination : MonoBehaviour, IBugDetermination
    {
        public void DetermineBug(AbstractDeveloper dev)
        {
            StartCoroutine(Determine(dev, 0.5f));
            //return dev;
        }

        private IEnumerator Determine(AbstractDeveloper dev, float repeatRate)
        {
            while (true)
            {
                var enemies = GameObject.FindGameObjectsWithTag(dev.BugTag);

                float shortestDistanceToEnemy = Mathf.Infinity;
                GameObject nearestEnemy = null;

                foreach (var enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy < shortestDistanceToEnemy)
                    {
                        shortestDistanceToEnemy = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
                }

                if (nearestEnemy != null && shortestDistanceToEnemy <= dev.Range)
                {
                    dev.Target = nearestEnemy.transform;
                }
                else
                {
                    dev.Target = null;
                }
                yield return new WaitForSeconds(repeatRate);
            }
        }
    }
}
