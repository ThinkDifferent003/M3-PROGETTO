using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    public int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage (int _damage )
    {
        _currentHealth -= _damage;
        Debug.Log($"{gameObject.name} ha subito {_damage} danni!");
        Debug.Log($"Vita rimanente: {_currentHealth}");

        if ( _currentHealth <= 0 )
        {
            Die();
        }
    }

    public void HealLife(int _heal)
    {
        _currentHealth += _heal;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        Debug.Log($"Vita rimanente a {_currentHealth}");
    }

    private void Die()
    {
        Debug.Log($"Il personaggio {gameObject.name} è stato sconfitto!");
        Destroy(gameObject , 1f);
    }
   
}
