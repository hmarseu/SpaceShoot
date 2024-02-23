using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spaceship _spaceshipPrefab;
    [SerializeField] GameUI _gameUI;
    //[SerializeField] MainMenu _mainMenu;

    int _score;
    int _enemyKilledCount;



    [SerializeField] private InputReader _input;
    [SerializeField] GameObject pauseMenu;

    bool _isPause = false;

    private void Start()
    {
        _input.PauseEvent += HandlePause;
        _input.ResumeEvent += HandleResume;

    }

    public void HandleResume()
    {
        _isPause = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void HandlePause()
    {
        _isPause = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

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
       NewGame();
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
        //var spaceship = Instantiate(_spaceshipPrefab);
        _gameUI.Spaceship = GameObject.FindAnyObjectByType<Spaceship>();
        _gameUI.ResetUI();
        _gameUI.gameObject.SetActive(true);
    }

    public void GameEnd()
    {
        _gameUI.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        //_mainMenu.gameObject.SetActive(true);
    }

    void OnSpaceshipDied(Spaceship spaceship)
    {
        GameEnd();
    }
}