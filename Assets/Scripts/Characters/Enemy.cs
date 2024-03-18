using Assets.Scripts.Characters.Behaviours;
using Assets.Scripts.GameMagaer;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class Enemy : Character, IShootable
    {
        [SerializeField] private EnemyPatrolRoute _enemyPatrolRoute;

        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            Move();
        }

        private void OnEnable()
        {
            EventBus.PlayerHided += StopChase;
            EventBus.PlayerDetected += FollowPlayer;
        }
        private void OnDisable()
        {
            EventBus.PlayerHided -= StopChase;
            EventBus.PlayerDetected -= FollowPlayer;
        }

        protected override void Move()
        {
            _enemyPatrolRoute.EnemyPatrolMove();
        }

        private void FollowPlayer()
        {
            Debug.Log("Follow Player!");
        }

        private void StopChase()
        {
            Debug.Log("Stop following!");
        }

        public void Shoot()
        {
            throw new System.NotImplementedException();
        }
    }
}
