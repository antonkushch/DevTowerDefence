using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Developers;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts
{
    public class JuniorDeveloper : AbstractDeveloper
    {
        protected override void Awake()
        {
            base.Awake();
            Range = 10f;
            Damage = 10;
            UpgradeCosts = new List<int> { 100, 300, 400 };
            UpgradeScaleChanges = new List<Vector3> { new Vector3(0.1f, 0.1f, 0.1f), new Vector3(0.2f, 0.2f, 0.2f), new Vector3(0.35f, 0.35f, 0.35f) };
            upgradeBoost = new UpgradeBoost(10, 10, 10);
            SellCosts = new List<int> { 50, 100, 300, 550 };
            slowDown = new SlowDown(5, 0.5f);
            BugTag = "Enemy";
            RotationSpeed = 5f;
            FireRate = 0.5f;
        }
    }
}
