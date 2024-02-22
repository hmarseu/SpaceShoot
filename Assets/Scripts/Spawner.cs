using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static Spawner;

public class Spawner : MonoBehaviour
{
    public int chanceToBeGolden=20;
    public SOWave[] waves;
    public SOWave[] bossWaves;
    SOWave currentWave;
    List<GameObject> currentWaveEnemys;
    int waveCount = 1;
    int enemyCount = 1;

    Camera cam;
    float maxX,minX;
    Vector3 topRight;
    Vector3 topLeft;

    GlobalPoolObject pool;
    
    bool waveFinished = false;

    EnDieCounter enDieCounter;
    public delegate void BossAppear();
    public static event BossAppear bossAppear;

    public delegate void BossDesappear();
    public static event BossDesappear bossDesappear;

    private void Start()
    {
        pool = GlobalPoolObject.Instance;
        enDieCounter = GetComponent<EnDieCounter>();
        cam = Camera.main;
        topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.farClipPlane));
        topLeft = cam.ViewportToWorldPoint(new Vector3(0,1, cam.farClipPlane));
        // Définir les limites de déplacement du joueur en fonction de la vue de la caméra
        minX = topLeft.x;
        maxX = topRight.x;
        waves = Resources.LoadAll<SOWave>("Waves");
        bossWaves = Resources.LoadAll<SOWave>("Bosses");
        if (waves.Length !=0)
        {
            currentWave = waves[0];
            currentWaveEnemys = currentWave.enemysInWave;
            enDieCounter.SetEnemyInWave(currentWaveEnemys.Count);
            StartCoroutine(WaveControl());
        }
        
    }
   
    public void FinishWave()
    {
        waveFinished = true;
        
    }

    private void passToNextWave()
    {
            waveFinished = false;
            enemyCount = 1;
            //parce qu'on commence a la vague 1 et pas 0
            currentWave = Instantiate(waves[waveCount]);
        
            waveCount++;
            currentWaveEnemys = currentWave.enemysInWave;
            enDieCounter.SetEnemyInWave(currentWaveEnemys.Count);

        
        

    }
    private void SpawneOneEnemy(int indexEnemy)
    {
        
        float location = Random.Range(minX, maxX);
        GameObject spawnee = pool.GetEmpty();
        if (currentWaveEnemys.Count >=indexEnemy)
        {           
            pool.MakeCopyFromPrefab(spawnee, currentWaveEnemys[indexEnemy]);
          
            spawnee.transform.position = new Vector3(location, topRight.y, 0);
            int tryGolden = Random.Range(0, 100);
            if (tryGolden<= chanceToBeGolden)
            {
                spawnee.TryGetComponent<SpriteRenderer>(out var rend);
                rend.color = new Color(255, 215, 0);
            }
        }
    }

    private void BossFight()
    {
        waveFinished = false;
        enemyCount = 1;
        
        currentWave = Instantiate(bossWaves[0]);
        currentWaveEnemys = currentWave.enemysInWave;
        enDieCounter.SetEnemyInWave(currentWaveEnemys.Count);

        StopAllCoroutines();
        //event UI apparition de sa barre de santé 
        
        float location = Random.Range(minX, maxX);
        GameObject Bspawnee = pool.GetEmpty();
        if (bossWaves.Length!=0)
        {
            int rand = Random.Range(0, bossWaves.Length);
            pool.MakeCopyFromPrefab(Bspawnee, bossWaves[rand].enemysInWave[0]);
            Debug.Log(bossWaves[rand].enemysInWave[0]);
            Bspawnee.transform.position = new Vector3(location, topRight.y, 0);
            Bspawnee.transform.localScale = new Vector3(2f, 2f, 1);
            bossAppear();
        }
        else
        {
            DefeatBoss();
        }
    }

    public void DefeatBoss()
    {
        bossDesappear();
         waveCount++;
        StartCoroutine(WaveControl());
    }
    IEnumerator WaveControl()
    {
        while (true) 
        {
            
            if (enemyCount <= currentWaveEnemys.Count)
            {
                yield return new WaitForSeconds(currentWave.timeBtwSpawn);
                SpawneOneEnemy(enemyCount-1);
                    
                enemyCount++;
                //enDieCounter.EnemyDie();


            }
            else if(waves.Length >= waveCount + 1)
            {
              
                if (waveCount % 3 == 0)
                {
                    BossFight();
                }
                else
                { 
                    if (waveFinished)
                    {
                       
                        yield return new WaitForSeconds(currentWave.timeBtwWave);
                        passToNextWave();
                    }
                
                }
            }
            else if (waveFinished) 
            {
              
                if (waveCount % 3 == 0)
                {
                    BossFight();
                }
                else
                {
                    waveCount++;
                    currentWave.timeBtwSpawn /= 1.2f;
                    currentWave.timeBtwWave /= 1.2f;
                
                    enemyCount = 1;
                    waveFinished = false;
                    enDieCounter.SetEnemyInWave(currentWaveEnemys.Count);
                }
            }
            yield return null;

            
        }
    }
}
