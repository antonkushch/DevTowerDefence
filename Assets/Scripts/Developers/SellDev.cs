using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Developers
{
    public class SellDev : MonoBehaviour, ISellable<AbstractDeveloper>
    {
        AbstractDeveloper dev;
        public void Sell(AbstractDeveloper entity)
        {
            dev = entity;
            Sell();
        }

        private void Sell()
        {
            //Debug.Log("Selling Dev for: " + dev.SellCosts[dev.UpgradeRank]);
            DealWithMoney();
            Destroying();
            RemoveUpgradeEffect();
        }

        private void DealWithMoney()
        {
            PlayerStuff.money += dev.SellCosts[dev.UpgradeRank];
        }

        private void Destroying()
        {
            Destroy(dev.gameObject);
        }

        private void RemoveUpgradeEffect()
        {
            Destroy(dev.InstantiatedUpgradeEffect);
        }
    }
}
