using UnityEngine;

namespace Assets.Scripts.Characters.Behaviours
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;

        void Update()
        {
            transform.Translate(Vector3.up * _bulletSpeed * Time.deltaTime);
        }
    }
}

