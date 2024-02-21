using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManagerInputs gameManager;
    [SerializeField] Button Pause;
    [SerializeField] Button Resume;
    [SerializeField] Button Quit;
    [SerializeField] TextMeshProUGUI FpsCompteur;
    [SerializeField] GameObject BossPanel;
    private void Start()
    {
        Pause.onClick.AddListener(gameManager.HandlePause);
        Resume.onClick.AddListener(gameManager.HandleResume);
        Quit.onClick.AddListener(Leave);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        Spawner.bossAppear += SpawnBoss;
        Spawner.bossDesappear += DespawnBoss;
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
    }
    private void Update()
    {
        //FpsCompteur.text = 
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "FPS: " + (int)(1.0f / Time.smoothDeltaTime));
    }
}
