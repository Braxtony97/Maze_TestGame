using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolRoute : MonoBehaviour
{
    [SerializeField] private Transform _patrolRoute;
    [SerializeField] private List<Transform> _locations;
    [SerializeField] private NavMeshAgent _enemyNavMesh;

    private int _locationIndex = 0;

    void Start()
    {
        InitializePatrolRoute();
    }

    void Update()
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
}
