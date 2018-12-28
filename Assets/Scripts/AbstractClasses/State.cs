using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public abstract class State
    {
        protected SpawningWaves waves;
        protected MonoBehaviour instance;

        public abstract void Tick();

        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        public State(SpawningWaves waves, MonoBehaviour instance)
        {
            this.waves = waves;
            this.instance = instance;
        }
    }
}
