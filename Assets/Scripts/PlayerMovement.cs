using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GetMousePosition _getMousePosition;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private int _speedMove = 5;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _getMousePosition.GetMousePositionVector();
            Debug.Log(_getMousePosition.MousePositionVector);
            //_navMeshAgent.destination = _getMousePosition.MousePositionVector;
            _navMeshAgent.SetDestination(_getMousePosition.MousePositionVector);
        }    
    }
}
