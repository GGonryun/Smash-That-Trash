using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] TextMeshProUGUI WaveNumber;
    [SerializeField] TextMeshProUGUI Health;
    [SerializeField] TextMeshProUGUI WordsBox;
    [SerializeField] Canvas GameOverScreen;
    [SerializeField] Canvas GameScreen;
    [SerializeField] Player player;
    [SerializeField] EntriesDisplay entriesDisplayer;

    void Start()
    {
        GameManager.Instance.WaveSpawned += UpdateWaveNumber;
        GameManager.Instance.GameOver += DisplayGameOverScreen;
        GameManager.Instance.InitializeGame += DisplayGameScreen;
        player.HealthTracker += UpdateHealth;
    }

    void OnDisable()
    {
        GameManager.Instance.WaveSpawned -= UpdateWaveNumber;
        GameManager.Instance.GameOver -= DisplayGameOverScreen;
        GameManager.Instance.InitializeGame -= DisplayGameScreen;
        player.HealthTracker -= UpdateHealth;

    }

    private void DisplayGameScreen(object sender, DataEventArgs<int> e)
    {
        entriesDisplayer.Clear();
        GameScreen.gameObject.SetActive(true);
        GameOverScreen.gameObject.SetActive(false);
    }

    private void DisplayGameOverScreen(object sender, DataEventArgs<Entries> e)
    {
        GameOverScreen.gameObject.SetActive(true);
        GameScreen.gameObject.SetActive(false);
        entriesDisplayer.Initialize(e.Data);
    }

    void UpdateWaveNumber(object sender, DataEventArgs<int> e)
    {
        WaveNumber.text = e.Data.ToString();
    }

    void UpdateHealth(object sender, DataEventArgs<int> e)
    {
        Health.text = e.Data.ToString();
    }

}
