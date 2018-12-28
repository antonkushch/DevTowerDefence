using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class SpawningEnemies
    {
        private Wave WaveToSpawn { get; set; }
        private MonoBehaviour Instance { get; set; }
        private int alreadySpawnedEnemies { get; set; }

        public SpawningEnemies(Wave wave, MonoBehaviour instance)
        {
            WaveToSpawn = wave;
            Instance = instance;
            alreadySpawnedEnemies = 0;
        }

        public void StartSpawningCoroutine()
        {
            Instance.StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            if (WaveToSpawn == null) yield break;

            PlayerStuff.IncrementWavesSurvived();

            System.Random rand = new System.Random();
            Debug.Log("Spawning wave " + WaveToSpawn.number + " with " + WaveToSpawn.enemyCount + " enemies!");

            AbstractBug nextBug;
            for (int i = 0; i < WaveToSpawn.enemyCount; i++)
            {
                nextBug = WaveToSpawn.bugs[rand.Next(0, WaveToSpawn.bugs.Count)];
                SpawnEnemy(nextBug);
                yield return new WaitForSeconds(WaveToSpawn.delayBetweenEnemies);
                alreadySpawnedEnemies++;
            }
            yield break;
        }

        private void SpawnEnemy(AbstractBug bug)
        {
            UnityEngine.Object.Instantiate(bug, bug.transform.position, bug.transform.rotation);
        }

        public bool IsSpawningDone()
        {
            return alreadySpawnedEnemies == WaveToSpawn.enemyCount;
        }
    }
}
