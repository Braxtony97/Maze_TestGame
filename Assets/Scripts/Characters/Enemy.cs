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
            EventBus.PlayerHided += FollowPlayer;
        }
        private void OnEDisable()
        {
            EventBus.PlayerHided -= FollowPlayer;
        }

        protected override void Move()
        {
            _enemyPatrolRoute.EnemyPatrolMove();
        }

        private void FollowPlayer()
        {
            Debug.Log("Follow Player!");
        }

        public void Shoot()
        {
            throw new System.NotImplementedException();
        }
    }
}
