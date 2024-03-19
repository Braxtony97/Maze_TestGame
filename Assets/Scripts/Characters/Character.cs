using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public abstract class Character : MonoBehaviour
    {
        public event Action<float> HealthChanged;

        [Range(0f, 200f)]
        [SerializeField] protected int _maxHealth;
        [SerializeField] protected string _projectileTag;
        [SerializeField] protected Transform _shootPoint;
        [SerializeField] protected float _reloadTimeShoot = 0.1f;
        [SerializeField] protected float _rotationSpeed = 10f;

        protected int _currentHealth;

        protected virtual void Start()
        {
            _currentHealth = _maxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            print(_currentHealth);
            if(_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                float _currentHealthAsPercantage = (float) _currentHealth / _maxHealth;
                HealthChanged?.Invoke(_currentHealthAsPercantage);
            }
        }

        protected abstract void Move();

        protected void SetAngle(Vector3 target)
        {
            Vector3 deltaPosition = target - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(deltaPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}
