using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] float frequency = .01f;
    [SerializeField] int maximumWords = 100;
    WordDictionary dictionary;
    Entries entries;

    void Awake()
    {
        dictionary = new WordDictionary(frequency, maximumWords);
        entries = new Entries();
    }

    void Start()
    {
        CreateWord();
    }

    void OnEnable()
    {
        Keyboard.Instance.Terminate += SubmitEntry;
    }

    private void OnDisable()
    {
        Keyboard.Instance.Terminate -= SubmitEntry;
    }

    public void SubmitEntry(object sender, KeyPressedEventArgs e)
    {
        KeyValuePair<string, string> currentWord = WordBuilder.Instance.ClearWord();
        entries.Add(new Entry(currentWord.Key, currentWord.Value, 0));
        CreateWord();
    }

    void CreateWord()
    {
        WordBuilder.Instance.CreateWord(dictionary.GetRandom());
    }
}
