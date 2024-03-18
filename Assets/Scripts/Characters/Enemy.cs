using Assets.Scripts.Characters.Behaviours;
using Assets.Scripts.GameMagaer;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class Enemy : Character, IShootable
    {
        [SerializeField] private EnemyPatrolRoute _enemyPatrolRoute;
        [SerializeField] private Transform _playerTransform;

        private ObjectPooler _pooler;

        protected override void Start()
        {
            base.Start();
            _pooler = ObjectPooler.Instance;
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
            _pooler.SpawnFromPool(_projectileTag, _shootPoint);
            Debug.Log("Follow Player!");
        }

        private void StopChase()
        {
            Debug.Log("Stop Chase");
            _enemyPatrolRoute.EnemyPatrolMove();
        }

        public void Shoot()
        {
            throw new System.NotImplementedException();
        }
    }
}
