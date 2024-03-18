using UnityEngine;

namespace Assets.Scripts.Characters.Behaviours
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private void LateUpdate()
        {
            transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
            transform.Rotate(0, 180, 0);
        }
    }
}
