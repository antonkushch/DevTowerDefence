using Assets.Scripts.Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class SeniorDeveloper : AbstractDeveloper
    {
        protected override void Awake()
        {
            base.Awake();
            Range = 17f;
            Damage = 100;
            UpgradeCosts = new List<int> { 400, 700, 1000 };
            UpgradeScaleChanges = new List<Vector3> { new Vector3(0.1f, 0.1f, 0.1f), new Vector3(0.2f, 0.2f, 0.2f), new Vector3(0.35f, 0.35f, 0.35f) };
            upgradeBoost = new UpgradeBoost(15, 15, 15);
            SellCosts = new List<int> { 100, 200, 260, 345 };
            BugTag = "Enemy";
            RotationSpeed = 9f;
            FireRate = 1f;
        }
    }
}
