using System;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] int _baseHealth;
    [SerializeField] float _invincibilityDuration;
    [SerializeField] float _fireRate;
    [SerializeField] List<ShotPattern> _shotPatterns;
    [SerializeField] BoxCollider2D _boxCollider2D;
    [SerializeField] GameObject _shield;
    [SerializeField] SpriteRenderer _spriteRenderer;

    int _health;
    int _bombCount;
    float _invincibilityCountdown;
    float _shootCooldown;
    bool _hasShield;
    readonly List<Collider2D> _overlapResults = new List<Collider2D>();

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

    public bool HasShield
    {
        get => _hasShield;
        set
        {
            _hasShield = value;
            _shield.SetActive(value);
        }
    }

    public int MaxMissileLevel => _shotPatterns.Count - 1;
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
        CheckCollision();
        ElapseShootCooldown();
        ElapseInvincibilityCountdown();

        void CheckCollision()
        {
            _overlapResults.Clear();
            var colliderCount = _boxCollider2D.OverlapCollider(new ContactFilter2D().NoFilter(), _overlapResults);

            foreach (var collider in _overlapResults)
            {
                if (collider == null)
                    continue;
                
                ProcessCollision(collider);
            }
        }
        
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

    void ProcessCollision(Collider2D col)
    {
        if (!col.TryGetComponent<Loot>(out var loot))
            return;
        
        loot.Use(this);
        Destroy(loot.gameObject);
    }

    [ContextMenu("Increment missile level")]
    public void Increment()
    {
        MissileLevel++;

        if (MissileLevel > MaxMissileLevel)
            MissileLevel = 0;
    }

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        var pattern = _shotPatterns[MissileLevel];

        for (var i = 0; i < pattern.MissileCount; i++)
        {
            var missile = ObjectPooling.Instance.GetProjectile();
            missile.transform.SetPositionAndRotation(
                transform.position + pattern.Missiles[i].position, 
                Quaternion.Euler(pattern.Missiles[i].direction)
            );
        }
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
        _spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        Invoke(nameof(ResetColor), _invincibilityDuration);
    }

    void ResetColor()
    {
        _spriteRenderer.color = Color.white;
    }
}