using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnDieCounter : MonoBehaviour
{
   [SerializeField] private int enemyInWave = 10;
    [SerializeField] private int enemyDied = 0;
    Spawner spawner;
  

    private void Start()
    {
        spawner = GetComponent<Spawner>();
    }
    public void SetEnemyInWave(int eInW)
    {
        enemyInWave = eInW;
        enemyDied = 0;
    }
    [ContextMenu("dieenemy")]
    public void EnemyDie()
    {
       
        enemyDied++;
        if (enemyDied == enemyInWave)
        {
           spawner.FinishWave();
          
        }
    }
    [ContextMenu("dieBoss")]
    public void BossDie()
    {
        spawner.DefeatBoss();
    }
 }
