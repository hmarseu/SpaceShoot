using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _bombText;
    [SerializeField] TextMeshProUGUI _invincibilityText;
    [SerializeField] TextMeshProUGUI _shieldText;

    public Spaceship Spaceship { get; set; }

    void OnEnable()
    {
        Spaceship = GameObject.FindAnyObjectByType<Spaceship>();
        _gameManager.ScoreChanged += OnScoreChanged;
        Spaceship.HealthChanged += OnHealthChanged;
        Spaceship.BombCountChanged += OnBombCountChanged;
    }

    void Update()
    {
        if (Spaceship == null)
            return;

        _invincibilityText.text = $"Invincibilité : {Spaceship.InvincibilityCountdown:#0.###}s";
        _shieldText.text = "Boucier : " + (Spaceship.HasShield ? "Actif" : "Inactif");
    }

    void OnDisable()
    {
        _gameManager.ScoreChanged -= OnScoreChanged;
        Spaceship.HealthChanged -= OnHealthChanged;
        Spaceship.BombCountChanged -= OnBombCountChanged;
    }

    public void ResetUI()
    {
        _scoreText.text = $" {_gameManager.Score}";
        _healthText.text = $"Santé : {Spaceship.Health}";
        _bombText.text = $"Bombe : {Spaceship.BombCount}";
        _invincibilityText.text = $"Invincibilité : {Spaceship.InvincibilityCountdown}s";
        _shieldText.text = $"Bouclier : " + (Spaceship.HasShield ? "Actif" : "Inactif");
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
}