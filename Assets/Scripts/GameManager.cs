using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}