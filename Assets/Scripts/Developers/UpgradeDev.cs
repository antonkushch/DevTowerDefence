using Assets.Scripts.Exceptions;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Developers
{
    public class UpgradeDev : MonoBehaviour, IUpgradable<AbstractDeveloper>
    {
        private AbstractDeveloper dev;

        public void Upgrade(AbstractDeveloper entity)
        {
            dev = entity;
            Upgrade();
        }

        private void Upgrade()
        {
            try
            {
                CheckingValidUpgrade();
            }
            catch(MaxUpgradeException)
            {
                return;
            }
            catch(NotEnoughMoneyException)
            {
                return;
            }
            ApplyUpgradeBoost();
            ApplyUpgradeEffect();
            DealWithMoney();
            dev.UpgradeRank++;
        }

        private void DealWithMoney()
        {
            PlayerStuff.money -= dev.UpgradeCosts[dev.UpgradeRank];
        }

        private void CheckingValidUpgrade()
        {
            if (dev.UpgradeRank >= dev.UpgradeCosts.Count)
            {
                throw new MaxUpgradeException("Dev is at highest rank.");
            }

            if (PlayerStuff.money < dev.UpgradeCosts[dev.UpgradeRank])
            {
                throw new NotEnoughMoneyException("Not enough money to upgrade.");
            }
        }

        private void ApplyUpgradeBoost()
        {
            dev.Range += ((float)dev.upgradeBoost.RangeBoostPercentage / 100) * dev.Range;
            dev.FireRate += ((float)dev.upgradeBoost.FireRateBoostPercentage / 100) * dev.FireRate;
            dev.Damage += Mathf.RoundToInt(((float)dev.upgradeBoost.DamageBoostPercentage / 100) * dev.Damage);
        }

        private void ApplyUpgradeEffect()
        {
            if (dev.UpgradeRank == 0)
            {
                dev.InstantiatedUpgradeEffect = Instantiate(dev.upgradeEffect, dev.transform.position, Quaternion.identity);
            }
            dev.transform.localScale += dev.UpgradeScaleChanges[dev.UpgradeRank];
        }
    }
}
