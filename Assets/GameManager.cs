using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public WordEventHandler WordCreated;
    public ScoreEventHandler WordCompleted;
    [SerializeField] float frequency = .01f;
    [SerializeField] int maximumWords = 100;
    [SerializeField] float spawnSpeed = 3f;
    [SerializeField] float difficulty = .05f;
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
    }

    void InitializeGame()
    {
        StopAllCoroutines();
        WordBuilder.Instance.ClearWord();
        CreateWord();
        player.Initialize();
        EnemySpawner.Instance.Clear();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            EnemySpawner.Instance.Spawn();
            yield return new WaitForSeconds(spawnSpeed);
            spawnSpeed = Mathf.Clamp(spawnSpeed - difficulty, 0.1f, 10f);
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

    void CompleteWord(object sender, KeyPressedEventArgs e)
    {
        SubmitWord();
        CreateWord();
    }

    void SubmitWord()
    {
        KeyValuePair<string, string> currentWord = WordBuilder.Instance.ClearWord();
        Entry entry = new Entry(currentWord.Key, currentWord.Value, LetterReader.Instance.Score);
        WordCompleted?.Invoke(this, new EntryEventArgs(entry));
    }

    void CreateWord()
    {
        Word word = WordBuilder.Instance.CreateWord(dictionary.GetRandom());
        WordCreated?.Invoke(this, new WordEventArgs(word));
    }
}
