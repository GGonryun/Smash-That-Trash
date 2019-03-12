using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void NewWordEventHandler(object sender, NewWordEventArgs e);

public class NewWordEventArgs : System.EventArgs
{
    public Word Word { get; private set; }
    public NewWordEventArgs(Word word)
    {
        this.Word = word;
    }
}


public class GameManager : Singleton<GameManager>
{

    public NewWordEventHandler WordCreated;
    [SerializeField] float frequency = .01f;
    [SerializeField] int maximumWords = 100;
    [SerializeField] LetterReader reader;
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
        Word word = WordBuilder.Instance.CreateWord(dictionary.GetRandom());
        WordCreated?.Invoke(this, new NewWordEventArgs(word));
    }
}
