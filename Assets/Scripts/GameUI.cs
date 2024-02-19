using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _bombText;
    [SerializeField] TextMeshProUGUI _invincibilityText;
    [SerializeField] TextMeshProUGUI _shieldText;

    GameManager _gameManager;
    Spaceship _spaceship;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _spaceship = FindObjectOfType<Spaceship>();
    }

    void OnEnable()
    {
        _gameManager.ScoreChanged += OnScoreChanged;
        _spaceship.HealthChanged += OnHealthChanged;
        _spaceship.BombCountChanged += OnBombCountChanged;
    }

    void Start()
    {
        ResetUI();
    }

    void Update()
    {
        if (_spaceship == null)
            return;

        _invincibilityText.text = $"Invincibilité : {_spaceship.InvincibilityCountdown:#0.###}s";
        _shieldText.text = "Boucier : " + (_spaceship.HasShield ? "Actif" : "Inactif");
    }

    void OnDisable()
    {
        _gameManager.ScoreChanged -= OnScoreChanged;
        _spaceship.HealthChanged -= OnHealthChanged;
        _spaceship.BombCountChanged -= OnBombCountChanged;
    }

    void OnScoreChanged(int newScore)
    {
        _scoreText.text = $"Score : {newScore}";
    }
    
    void OnHealthChanged(int newHealth)
    {
        _healthText.text = $"Santé : {newHealth}";
    }

    void OnBombCountChanged(int newBombCount)
    {
        _bombText.text = $"Bombe : {newBombCount}";
    }

    void ResetUI()
    {
        _scoreText.text = $"Score : {0}";
        _healthText.text = $"Santé : {3}";
        _bombText.text = $"Bombe : {0}";
        _invincibilityText.text = $"Invincibilité : {0}s";
        _shieldText.text = $"Bouclier : {"Inactif"}";
    }
}