using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Behaviours
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private string _myTag = "";
        [SerializeField] private string _colliderEnemyDetected = "ColliderEnemyDetected";
        [SerializeField] private int _damage = 5;


        void Update()
        {
            if(gameObject.activeSelf)
            {
                StartCoroutine(CoroutineBulletLife());
                transform.Translate(Vector3.up * _bulletSpeed * Time.deltaTime);
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Character>() != null && other.gameObject.tag != _myTag && other.gameObject.tag != _colliderEnemyDetected)
            {
                other.gameObject.GetComponent<Character>().TakeDamage(_damage);
                gameObject.SetActive(false);
            }
        }

        private IEnumerator CoroutineBulletLife()
        {
            yield return new WaitForSeconds(5);
            gameObject.SetActive(false);
        }
    }
}

