using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.DevAttack
{
    public class DefaultTakeDamageAttack: MonoBehaviour, IBaseAttack<AbstractDeveloper>
    {
        public void Attack(AbstractDeveloper attackBy)
        {
            BaseAttack(attackBy);
        }

        public void BaseAttack(AbstractDeveloper attackBy)
        {
            var newbug = attackBy.Target.GetComponent<AbstractBug>();
            newbug.TakeDamage(attackBy.Damage);
        }
    }
}
