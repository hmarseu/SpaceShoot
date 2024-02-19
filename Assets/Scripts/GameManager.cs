using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spaceship _spaceshipPrefab;
    [SerializeField] GameUI _gameUI;
    [SerializeField] MainMenu _mainMenu;

    int _score;
    int _enemyKilledCount;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            ScoreChanged?.Invoke(_score);
        }
    }

    public int EnemyKilledCount
    {
        get => _enemyKilledCount;
        set
        {
            _enemyKilledCount = value;
            EnemyKilledCountChanged?.Invoke(_enemyKilledCount);
        }
    }

    public Action<int> ScoreChanged { get; set; }
    public Action<int> EnemyKilledCountChanged { get; set; }

    void OnEnable()
    {
        Spaceship.SpaceshipDied += OnSpaceshipDied;
    }

    void OnDisable()
    {
        Spaceship.SpaceshipDied -= OnSpaceshipDied;
    }

    public void NewGame()
    {
        Score = 0;
        EnemyKilledCount = 0;
        var spaceship = Instantiate(_spaceshipPrefab);
        _gameUI.Spaceship = spaceship;
        _gameUI.ResetUI();
        _gameUI.gameObject.SetActive(true);
    }

    public void GameEnd()
    {
        _gameUI.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(true);
    }

    void OnSpaceshipDied(Spaceship spaceship)
    {
        GameEnd();
    }
}