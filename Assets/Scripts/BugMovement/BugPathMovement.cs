using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Pathfinding;
using UnityEngine.EventSystems;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts
{
    public class BugPathMovement : MonoBehaviour, IMovement<AbstractBug>
    {
        public Transform target;
        public float distanceToWaypoint;
        private int currentWaypoint;
        private Seeker seeker;
        private Path path;
        
        //public Canvas onTopOfBug;

        //private CharacterController characterController;

        void Awake()
        {
            seeker = GetComponent<Seeker>();
            seeker.StartPath(transform.position, target.position, OnPathComplete);
            //characterController = GetComponent<CharacterController>();
        }

        public void OnPathComplete(Path p)
        {
            if (!p.error)
            {
                path = p;
                currentWaypoint = 0;
            }
            else
            {
                Debug.Log(p.error);
            }
        }

        public void Move(AbstractBug gameObject)
        {
            if (path == null)
                return;

            if (CheckEndOfPath())
            {
                return;
            }

            Vector3 direction = (path.vectorPath[currentWaypoint] - transform.position);//.normalized * speed * Time.fixedDeltaTime;

            if (direction != Vector3.zero)
            {
                gameObject.transform.rotation = Quaternion.Slerp(
                    gameObject.transform.rotation,
                    Quaternion.LookRotation(direction),
                    Time.deltaTime * gameObject.rotationSpeed
                );
            }
            //characterController.Move(direction);
            transform.Translate(direction.normalized * gameObject.speed * Time.deltaTime, Space.World);

            if (IsCloseToNextWaypoint(distanceToWaypoint))
                GetNextWaypoint();
        }

        private bool IsCloseToNextWaypoint(float distanceToWaypoint)
        {
            return Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) <= distanceToWaypoint ? true : false;
        }

        private void GetNextWaypoint()
        {
            currentWaypoint++;
        }

        private bool CheckEndOfPath()
        {
            if (currentWaypoint >= path.vectorPath.Count)
            {
                EndOfPath();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EndOfPath()
        {
            PlayerStuff.DecreaseHealth();
            //ExecuteEvents.Execute<IEnemyReachedEnd>(playerStuff.gameObject, null, (x, y) => x.OnEnemyReachedEnd());
            Destroy(gameObject);
        }
    }
}
