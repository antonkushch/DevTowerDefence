using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class WaitingState : State
    {
        public WaitingState(SpawningWaves waves, MonoBehaviour instance) : base(waves, instance)
        { }
        
        public override void Tick()
        {
            if (!EnemyIsAlive() && waves.nextWave >= waves.waves.Length)
            {
                PlayerStuff.SetGameWon();
            }
            else
            if(!EnemyIsAlive())
            {
                waves.SetState(new SpawningState(waves, instance));
            }
            else
                return;
        }

        private bool EnemyIsAlive()
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void OnStateEnter()
        {
            waves.nextWave++;
        }
    }
}
