using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;
    private float _health;

    public float MaxHealth { get => _maxHealth; }
    public float MaxHealthAsInt { get=>Mathf.RoundToInt(_maxHealth); }
    public float Health { get => _health; }
    public int HealthAsInt { get=>Mathf.RoundToInt(_health); }

    public UnityEvent OnTakeDamage;
    public UnityEvent OnDeath;
    public UnityEvent OnHealed;

    public void TakeDamage(GameObject source, float damage)
    {
        if (damage <= 0) return;
        _health = Mathf.Clamp(Health - damage, 0, _maxHealth);
        OnTakeDamage.Invoke();

        if (_health == 0)
            OnDeath.Invoke();
    }
    public void Heal(GameObject source, float health)
    {
        if (health <= 0) return;
        _health = Mathf.Clamp(Health + health, 0, _maxHealth);
        OnHealed.Invoke();
    }
}
