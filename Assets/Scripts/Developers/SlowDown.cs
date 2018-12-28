using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Developers
{
    public class SlowDown
    {
        public float SlowDownTime;
        public float SlowDownPercentage;

        public SlowDown(float slowDownTime, float slowDownPercentage)
        {
            SlowDownTime = slowDownTime;
            SlowDownPercentage = slowDownPercentage;
        }
    }
}
