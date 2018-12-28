using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Developers;
using Assets.Scripts.Exceptions;

namespace Assets.Scripts
{
    public class AbstractDeveloper : MonoBehaviour
    {
        private Transform target;
        public Transform Target { get { return target; } set { target = value; } }

        private float range;
        public float Range { get { return range; } set { range = value; } }

        private int damage;
        public int Damage { get { return damage; } set { damage = value; } }

        private List<int> upgradeCosts;
        public List<int> UpgradeCosts { get { return upgradeCosts; } set { upgradeCosts = value; } }

        private List<Vector3> upgradeScaleChanges;
        public List<Vector3> UpgradeScaleChanges { get { return upgradeScaleChanges; } set { upgradeScaleChanges = value; } }

        private int upgradeRank = 0;
        public int UpgradeRank { get { return upgradeRank; } set { upgradeRank = value; } }

        private List<int> sellCosts;
        public List<int> SellCosts { get { return sellCosts; } set { sellCosts = value; } }

        public UpgradeBoost upgradeBoost;

        // slow down parameters class
        public SlowDown slowDown;
        
        private string bugTag;
        public string BugTag { get { return bugTag; } set { bugTag = value; } }

        private float rotationSpeed;
        public float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }

        private float fireRate;
        public float FireRate { get { return fireRate; } set { fireRate = value; } }

        private float fireCountdown = 0f;
        public float FireCountdown { get { return fireCountdown; } set { fireCountdown = value; } }

        public Transform bulletFirePosition;

        public GameObject upgradeEffect;
        private GameObject instantiatedUpgradeEffect;
        public GameObject InstantiatedUpgradeEffect { get { return instantiatedUpgradeEffect; } set { instantiatedUpgradeEffect = value; } }

        private IBugDetermination bugDetermination;
        private IShoot<AbstractDeveloper> shooting;
        public List<IAttack<AbstractDeveloper>> attacks;

        protected virtual void Awake()
        {
            bugDetermination = GetComponent<IBugDetermination>();
            shooting = GetComponent<IShoot<AbstractDeveloper>>();
            attacks = GetComponents<IAttack<AbstractDeveloper>>().ToList();
        }

        void Start()
        {
            bugDetermination.DetermineBug(this);
        }

        void Update()
        {
            if (Target == null)
                return;

            RotateTowardsBug();
            if(shooting != null)
                shooting.Shoot(this);
        }

        protected void RotateTowardsBug()
        {
            Vector3 direction = Target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        protected void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, range);
        }

        public int CostToUpgrade()
        {
            if (UpgradeRank >= UpgradeCosts.Count)
                throw new MaxUpgradeException("Max");
            else
                return UpgradeCosts[UpgradeRank];
        }

        public int CostToSell()
        {
            if (UpgradeRank >= SellCosts.Count)
                throw new CantSellException("Can't");
            else
                return SellCosts[UpgradeRank];
        }
    }
}
