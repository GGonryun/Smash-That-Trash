using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public WordEventHandler WordCreated;
    public ScoreEventHandler WordCompleted;
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
        Keyboard.Instance.Terminate += CompleteWord;
    }

    private void OnDisable()
    {
        Keyboard.Instance.Terminate -= CompleteWord;
    }

    public void CompleteWord(object sender, KeyPressedEventArgs e)
    {
        SubmitWord();
        CreateWord();
    }

    private void SubmitWord()
    {
        KeyValuePair<string, string> currentWord = WordBuilder.Instance.ClearWord();
        entries.Add(new Entry(currentWord.Key, currentWord.Value, LetterReader.Instance.Score));
        WordCompleted?.Invoke(this, new ScoreEventArgs(LetterReader.Instance.Score));
    }

    void CreateWord()
    {
        Word word = WordBuilder.Instance.CreateWord(dictionary.GetRandom());
        WordCreated?.Invoke(this, new WordEventArgs(word));
    }
}
