using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class SpawningState : State
    {
        private SpawningEnemies enemiesSpawning;
        private bool spawningStarted;

        public SpawningState(SpawningWaves waves, MonoBehaviour instance) : base(waves, instance)
        {
            enemiesSpawning = new SpawningEnemies(waves.GetWaveByIndex(waves.nextWave), instance);
            spawningStarted = false;
        }

        public override void Tick()
        {
            ProcessSpawning();
        }

        private void ProcessSpawning()
        {
            if (!spawningStarted)
            {
                spawningStarted = true;
                enemiesSpawning.StartSpawningCoroutine();
            }
            if(enemiesSpawning.IsSpawningDone())
                waves.SetState(new WaitingState(waves, instance));
        }

        public override void OnStateEnter()
        {
            waves.waveCountdown = waves.timeBetweenWaves;
        }
    }
}
