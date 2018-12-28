using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Developers
{
    public class UpgradeBoost
    {
        public int DamageBoostPercentage { get; set; }
        public int RangeBoostPercentage { get; set; }
        public int FireRateBoostPercentage { get; set; }

        public UpgradeBoost(int damageBoost, int rangeBoost, int fireRateBoost)
        {
            DamageBoostPercentage = damageBoost;
            RangeBoostPercentage = rangeBoost;
            FireRateBoostPercentage = fireRateBoost;
        }
    }
}
