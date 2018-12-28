using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class NoNullCheckBug : AbstractBug
    {
        void Start()
        {
            rank = 2;
            health = startHealth = 120f;
            speed = startSpeed = 4f;
            reward = 60;
        }
    }
}
