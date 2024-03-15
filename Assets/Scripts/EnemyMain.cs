using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class EnemyMain : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 50;

    protected int _currentHealth;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    protected abstract void Move();
}
