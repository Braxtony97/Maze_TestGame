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
        [SerializeField] private float _distanceToPlayer = 5f;

        private ObjectPooler _pooler;
        private Player _player;
        private Transform _target;
        private float _timerShoot;

        protected override void Start()
        {
            base.Start();
            _pooler = ObjectPooler.Instance;
            _player = Player.Instance;
            _target = _player.transform;

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
            _enemyPatrolRoute.StopAgent();
            
            if (Vector3.Distance(transform.position, _target.position) > _distanceToPlayer)
            {
                _enemyPatrolRoute.FollowPlayer();
            }
            SetAngle(_target.position);
            if (_timerShoot <= 0)
                {
                    Shoot();
                    _audioManager.SFXPlay(_audioManager._audioSFXClipList[0]);
                    _timerShoot = _reloadTimeShoot;
                }
            else
                    _timerShoot -= Time.deltaTime;

        }

        private void StopChase()
        {
            _enemyPatrolRoute.EnemyPatrolMove();
        }

        public void Shoot()
        {
            _pooler.SpawnFromPool(_projectileTag, _shootPoint);
        }
    }
}
