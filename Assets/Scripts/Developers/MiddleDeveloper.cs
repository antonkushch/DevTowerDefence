using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Developers
{
    public class MiddleDeveloper : AbstractDeveloper
    {
        protected override void Awake()
        {
            base.Awake();
            Range = 14f;
            Damage = 20;
            UpgradeCosts = new List<int> { 300, 400, 600 };
            UpgradeScaleChanges = new List<Vector3> { new Vector3(0.1f, 0.1f, 0.1f), new Vector3(0.2f, 0.2f, 0.2f), new Vector3(0.35f, 0.35f, 0.35f) };
            upgradeBoost = new UpgradeBoost(13, 13, 13);
            SellCosts = new List<int> { 65, 205, 340, 450 };
            BugTag = "Enemy";
            RotationSpeed = 7f;
            FireRate = 0.7f;
        }
    }
}
