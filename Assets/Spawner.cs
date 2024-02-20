using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SOWave[] waves;
    SOWave currentWave;
    List<GameObject> currentWaveEnemys;
    int waveCount = 1;
    int enemyCount = 1;

    Camera cam;
    float maxX,minX;
    Vector3 topRight;
    Vector3 topLeft;


    private void Start()
    {
        cam = Camera.main;
        topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.farClipPlane));
        topLeft = cam.ViewportToWorldPoint(new Vector3(0,1, cam.farClipPlane));
        // Définir les limites de déplacement du joueur en fonction de la vue de la caméra
        minX = topLeft.x;
        maxX = topRight.x;
        waves = Resources.LoadAll<SOWave>("Waves");
        if (waves.Length !=0)
        {
            currentWave = waves[0];
            currentWaveEnemys = currentWave.enemysInWave;
            StartCoroutine(WaveControl());
        }
    }

    private void passToNextWave()
    {
            enemyCount = 1;
            //parce qu'on commence a la vague 1 et pas 0
            currentWave = Instantiate(waves[waveCount]);
        
           
        
            waveCount++;
            currentWaveEnemys = currentWave.enemysInWave;
        
    }
    private void SpawneOneEnemy(int indexEnemy)
    {
        float location = Random.Range(minX, maxX);

        
        GameObject spawnee = EnnemyPooling.Instance.GetTurret();
        spawnee.transform.position = new Vector3(location, topRight.y, 0);
    }
    IEnumerator WaveControl()
    {
        while (true) 
        {
            if (enemyCount <= currentWaveEnemys.Count)
            {
                yield return new WaitForSeconds(currentWave.timeBtwSpawn);
                SpawneOneEnemy(enemyCount);
                //Debug.Log($@"nous sommes a la vage {waveCount} dans cette vague nous sommes a l'enemy {enemyCount} sur {currentWaveEnemys.Count}");
                enemyCount++;
            }
            else if(waves.Length >= waveCount + 1)
            {
                yield return new WaitForSeconds(currentWave.timeBtwWave);
                passToNextWave();
            }
            else 
            {
                currentWave.timeBtwSpawn /= 1.2f;
                currentWave.timeBtwWave /= 1.2f;
                
                enemyCount = 1;
            }
            //yield return null;
        }
    }
}
