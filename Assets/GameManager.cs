using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public WordEventHandler WordCreated;
    public EntryEventHandler WordCompleted;
    [SerializeField] float frequency = .01f;
    [SerializeField] int maximumWords = 100;
    [SerializeField] float spawnSpeed = 3f;
    [SerializeField] float difficulty = .05f;
    [SerializeField] Enemy blackHole;
    public int waveNumber = 0;
    public int WaveNumber { get => waveNumber; }
    WordDictionary dictionary;
    Player player;

    protected override void Awake()
    {
        base.Awake();
        dictionary = new WordDictionary(frequency, maximumWords);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            InitializeGame();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        waveNumber = 0;
        Keyboard.Instance.Disable();
        StopAllCoroutines();
        EnemySpawner.Instance.Clear();
        WordBuilder.Instance.ClearWord();
    }

    public void InitializeGame()
    {
        waveNumber++;
        Keyboard.Instance.Enable();
        CreateWord();
        player.Initialize();
        StartCoroutine(SpawnEnemies());
        blackHole.Initialize(new Vector2(0, -40f), -1);
    }

    private IEnumerator SpawnEnemies()
    {
        float waveCount = 3;
        while(true)
        {
            Debug.Log(Mathf.FloorToInt(waveCount));
            for(int i = 0; i < Mathf.FloorToInt(waveCount); i++)
            {
                yield return new WaitForSeconds(.15f);
                EnemySpawner.Instance.Spawn();
            }
            yield return new WaitForSeconds(spawnSpeed);
            spawnSpeed = UnityEngine.Random.Range(spawnSpeed * .945f, spawnSpeed * 1.045f);
            waveCount *= (1 + difficulty);
            waveNumber++;
        }
    }

    void OnEnable()
    {
        Keyboard.Instance.Terminate += CompleteWord;
    }

    void OnDisable()
    {
        Keyboard.Instance.Terminate -= CompleteWord;
    }

    void CompleteWord(object sender, DataEventArgs<KeyCode> e)
    {
        SubmitWord();
        CreateWord();
    }

    void SubmitWord()
    {
        KeyValuePair<string, string> currentWord = WordBuilder.Instance.ClearWord();
        Entry entry = new Entry(currentWord.Key, currentWord.Value, LetterReader.Instance.Score);
        WordCompleted?.Invoke(this, new DataEventArgs<Entry>(entry));
    }

    void CreateWord()
    {
        Word word = WordBuilder.Instance.CreateWord(dictionary.GetRandom());
        WordCreated?.Invoke(this, new DataEventArgs<Word>(word));
    }
}
