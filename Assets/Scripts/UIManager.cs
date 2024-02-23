using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static HitableBoss;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Button Pause;
    [SerializeField] Button Resume;
    [SerializeField] Button Quit;
    //[SerializeField] TextMeshProUGUI FpsCompteur;
    [SerializeField] GameObject BossPanel;
    [SerializeField] GameObject BossLifeBar;
    private void Start()
    {
        Pause.onClick.AddListener(gameManager.HandlePause);
        Resume.onClick.AddListener(gameManager.HandleResume);
        Quit.onClick.AddListener(Leave);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        
    }
    private void OnEnable()
    {
        Spawner.bossAppear += SpawnBoss;
        Spawner.bossDesappear += DespawnBoss;

        HitableBoss.bossTakeHit += takehit;
    }
    private void OnDisable()
    {
        Spawner.bossAppear -= SpawnBoss;
        Spawner.bossDesappear -= DespawnBoss;

        HitableBoss.bossTakeHit -= takehit;
    }
    private void Leave()
    {
        gameManager.HandleResume();
        SceneManager.LoadScene(0);
    }
    private void SpawnBoss()
    {
        BossPanel.SetActive(true);
    }
    private void DespawnBoss()
    {
        BossPanel.SetActive(false);
        BossLifeBar.transform.localScale = new Vector3(1, 1);
    }
    private void Update()
    {
        //FpsCompteur.text = 
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "FPS: " + (int)(1.0f / Time.smoothDeltaTime));
    }
    void takehit(int lp,int totallp)
    {
        BossLifeBar.transform.localScale =new Vector3( lp / totallp,1);
    }
}
