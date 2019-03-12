using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public WordEventHandler WordCreated;
    public WordEventArgs WordCompleted;
    [SerializeField] float frequency = .01f;
    [SerializeField] int maximumWords = 100;
    WordDictionary dictionary;
    Entries entries;

    protected override void Awake()
    {
        base.Awake();
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
        entries.Add(new Entry(currentWord.Key, currentWord.Value, LetterReader.Instance.Score));

        CreateWord();
    }

    void CreateWord()
    {
        Word word = WordBuilder.Instance.CreateWord(dictionary.GetRandom());
        WordCreated?.Invoke(this, new WordEventArgs(word));
    }
}
