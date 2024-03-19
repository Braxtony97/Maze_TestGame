using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Characters.Behaviours
{
    public class EnemyPatrolRoute : MonoBehaviour
    {
        [SerializeField] private Transform _patrolRoute;
        [SerializeField] private List<Transform> _locations;
        [SerializeField] private NavMeshAgent _enemyNavMesh;

        private int _locationIndex = 0;
        private Player _player;
        private Transform _target;

        void Start()
        {
            InitializePatrolRoute();
            _player = Player.Instance;
            _target = _player.transform;
        }

        public void EnemyPatrolMove()
        {
            if (_enemyNavMesh.remainingDistance < 0.2f && !_enemyNavMesh.pathPending)
            {
                MoveToNextPatrolLocation();
            }
        }

        void InitializePatrolRoute()
        {
            foreach (Transform childLocation in _patrolRoute)
            {
                _locations.Add(childLocation);
            }
        }

        void MoveToNextPatrolLocation()
        {
            if (_locations.Count == 0)
                return;

            _enemyNavMesh.destination = _locations[_locationIndex].position;

            _locationIndex = (_locationIndex + 1) % _locations.Count;
        }

        public void StopAgent()
        {
            if (_enemyNavMesh != null && _enemyNavMesh.isActiveAndEnabled)
            {
                _enemyNavMesh.isStopped = true; // Остановка NavMesh Agent
                _enemyNavMesh.ResetPath(); // Сброс пути навигации
            }
        }

        public void FollowPlayer()
        {
            _enemyNavMesh.destination = _target.position;
        }
    }
}

