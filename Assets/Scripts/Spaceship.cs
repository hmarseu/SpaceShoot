using System;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] int _baseHealth;
    [SerializeField] float _invincibilityDuration;

    int _health;
    int _bombCount;
    float _invincibilityCountdown;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            HealthChanged?.Invoke(_health);
        }
    }
    
    public int BombCount
    {
        get => _bombCount;
        set
        {
            _bombCount = value;
            BombCountChanged?.Invoke(_bombCount);
        }
    }

    public bool HasShield { get; set; }

    public float InvincibilityCountdown
    {
        get => _invincibilityCountdown;
        set
        {
            if (value < 0)
                value = 0;

            _invincibilityCountdown = value;
        }
    }

    public bool IsInvincible => InvincibilityCountdown > 0;
    
    public Action<int> HealthChanged { get; set; }
    public Action<int> BombCountChanged { get; set; }

    void Awake()
    {
        Health = _baseHealth;
    }

    void Update()
    {
        if (InvincibilityCountdown > 0)
            InvincibilityCountdown -= Time.deltaTime;
    }

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        
    }

    [ContextMenu("Hit")]
    public void Hit()
    {
        if (IsInvincible)
            return;
        
        if (HasShield)
        {
            HasShield = false;
            return;
        }

        Health--;
        
        if (Health == 0)
            Die();
        else
            SetInvincibilityFrame();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void SetInvincibilityFrame()
    {
        InvincibilityCountdown = _invincibilityDuration;
    }
}