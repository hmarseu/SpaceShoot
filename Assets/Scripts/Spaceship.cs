using System;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] int _baseHealth;
    [SerializeField] float _invincibilityDuration;
    [SerializeField] float _fireRate;

    public GameObject missilePrefab;

    public GameObject turretCannon;

    int _health;
    int _bombCount;
    float _invincibilityCountdown;
    float _shootCooldown;
    
    public static Action<Spaceship> SpaceshipDied { get; set; }

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
    public int MissileLevel { get; set; }

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
        ElapseShootCooldown();
        ElapseInvincibilityCountdown();

        void ElapseShootCooldown()
        {
            if (_shootCooldown > 0)
            {
                _shootCooldown -= Time.deltaTime;
                return;
            }

            Shoot();
            _shootCooldown += _fireRate;
        }

        void ElapseInvincibilityCountdown()
        {
            if (InvincibilityCountdown > 0)
                InvincibilityCountdown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent<Loot>(out var loot))
            return;
        
        loot.Use(this);
    }

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        GameObject missile = ObjectPooling.Instance.GetProjectile();
        missile.transform.position = turretCannon.transform.position;
        missile.transform.rotation =  Quaternion.Euler(turretCannon.transform.rotation.x, turretCannon.transform.rotation.y, turretCannon.transform.rotation.z );

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
        MissileLevel = 0;
        
        if (Health == 0)
            Die();
        else
            SetInvincibilityFrame();
    }

    public void Die()
    {
        Destroy(gameObject);
        SpaceshipDied?.Invoke(this);
    }

    public void SetInvincibilityFrame()
    {
        InvincibilityCountdown = _invincibilityDuration;
    }
}