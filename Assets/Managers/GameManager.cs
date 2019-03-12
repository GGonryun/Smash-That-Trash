using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] float frequency = .01f;
    [SerializeField] int maximumWords = 100;
    [SerializeField] LetterSpawner letterSpawner;
    WordDictionary dictionary;
    Entries entries;

    void Awake()
    {
        dictionary = new WordDictionary(frequency, maximumWords);
        entries = new Entries();
    }

    void OnEnable()
    {
        Keyboard.Instance.Terminate += SubmitWord;
    }

    void OnDisable()
    {
        Keyboard.Instance.Terminate -= SubmitWord;
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
        var pair = dictionary.GetRandom();
        string word = pair.Key;
        for (int i = 0; i < word.Length; i++)
        {
            letterSpawner.CreateLetter(word[i]);
        }

    }

    void SubmitWord(object sender, KeyPressedEventArgs e)
    {
        letterSpawner.ClearWord();
    }

}
