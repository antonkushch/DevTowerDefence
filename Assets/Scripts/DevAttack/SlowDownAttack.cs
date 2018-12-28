using Assets.Scripts.Developers;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.DevAttack
{
    public class SlowDownAttack : MonoBehaviour, ISpecialAttack<AbstractDeveloper>
    {
        public void Attack(AbstractDeveloper attackBy)
        {
            SpecialAttack(attackBy);
        }

        public void SpecialAttack(AbstractDeveloper attackBy)
        {
            if (attackBy.slowDown != null)
            {
                var newbug = attackBy.Target.GetComponent<AbstractBug>();
                SlowDown(attackBy.slowDown.SlowDownTime, attackBy.slowDown.SlowDownPercentage, newbug);
            }
        }

        private void SlowDown(float time, float percent, AbstractBug bug)
        {
            StartCoroutine(SlowDownCoroutine(time, percent, bug));
        }

        private IEnumerator SlowDownCoroutine(float time, float percent, AbstractBug bug)
        {
            bug.coroutineRunning.Add(true);
            bug.speed = bug.startSpeed * (1f - percent);
            yield return new WaitForSeconds(time);
            bug.coroutineRunning.Add(false);

            if (bug.IsSlowedDown() == false)
            {
                bug.RestoreSpeed();
            }
        }
    }
}
