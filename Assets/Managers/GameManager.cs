using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] float frequency = .01f;
    [SerializeField] int maximumWords = 100;
    [SerializeField] WordManager wordManager;
    WordDictionary dictionary;
    Entries entries;

    void Awake()
    {
        dictionary = new WordDictionary(frequency, maximumWords);
        entries = new Entries();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            CreateWord();
        }
    }

    void CreateWord()
    {
        wordManager.CreateWord(dictionary.GetRandom());
    }

    public void SubmitEntry(Entry entry)
    {
        entries.Add(entry);
    }
}
