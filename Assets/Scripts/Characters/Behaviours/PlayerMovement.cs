using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Characters.Behaviours
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private LayerMask _floorLayerMask;

        private bool _hasReachedDestination = true;

        private void Update()
        {
            if (_navMeshAgent.remainingDistance < 0.2f && !_navMeshAgent.pathPending)
            {
                if (!_hasReachedDestination)
                {
                    Debug.Log("Idle");
                    _animator.SetTrigger("Idle");
                    _hasReachedDestination = true;
                }
            }
        }

        public void Move()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycastHit, 1000, _floorLayerMask))
                {
                    _navMeshAgent.SetDestination(raycastHit.point);
                    Debug.Log("Floor");
                    _animator.SetTrigger("Sneaking");
                    _hasReachedDestination = false;
                }
            }
        }
    }
}
