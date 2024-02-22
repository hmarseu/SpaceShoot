
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnDieCounter : MonoBehaviour
{
    [SerializeField] private int enemyInWave = 10;
    [SerializeField] private int enemyDied = 0;
    Spawner spawner;

    [SerializeField] List<GameObject> Loots;

    private void OnEnable()
    {
        Hitable.enemyDie += EnemyDie;
        EnemyAI.enemyDie += EnemyDie;
    }
    private void OnDisable()
    {
        Hitable.enemyDie -= EnemyDie;
    }
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
    public void EnemyDie(Vector3 position,bool isGolden)
    {
        if (isGolden)
        {
            int rand = Random.Range(0,Loots.Count);
            Instantiate(Loots[rand],position,Quaternion.identity);

        }
        enemyDied++;
        if (enemyDied >= enemyInWave)
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
