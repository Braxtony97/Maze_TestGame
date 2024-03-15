using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GetMousePosition _getMousePosition;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;

    [SerializeField] private string _projectileTag;
    [SerializeField] private Transform _shootPoint;

    private bool _hasReachedDestination = true;
    private ObjectPooler _pooler;

    private void Start()
    {
        _pooler = ObjectPooler.Instance;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _getMousePosition.GetMousePositionVector(); 
            _navMeshAgent.SetDestination(_getMousePosition.MousePositionVector);
            _animator.SetTrigger("Sneaking");
            _hasReachedDestination = false;
            Debug.Log("Sneaking");
        }
        if (_navMeshAgent.remainingDistance < 0.2f && !_navMeshAgent.pathPending)
        {
            if (!_hasReachedDestination)
            {
                Debug.Log("Call");
                _animator.SetTrigger("Idle");
                _hasReachedDestination = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            _pooler.SpawnFromPool(_projectileTag, _shootPoint);
        }
    }

}
