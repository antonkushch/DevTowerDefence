using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    [Serializable]
    public class Wave
    {
        public string name;
        public string number;
        public List<AbstractBug> bugs;
        public int enemyCount;
        public float delayBetweenEnemies;
    }
}
