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
        [Range(0f, 200f)]
        [SerializeField] protected int _maxHealth;
        [SerializeField] protected int _minHealth;
        [SerializeField] protected string _projectileTag;
        [SerializeField] protected Transform _shootPoint;

        protected int _currentHealth;

        protected virtual void Start()
        {
            _currentHealth = _maxHealth;
        }

        protected virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;
        }

        protected abstract void Move();
    }
}
