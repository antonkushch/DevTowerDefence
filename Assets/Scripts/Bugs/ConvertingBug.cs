using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class ConvertingBug : AbstractBug
    {
        void Start()
        {
            rank = 1;
            health = startHealth = 140f;
            speed = startSpeed = 7f;
            reward = 30;
        }
    }
}
