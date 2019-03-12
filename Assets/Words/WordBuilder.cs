using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBuilder : Singleton<WordBuilder>
{
    [SerializeField] LetterSpawner letterSpawner;
    private KeyValuePair<string, string> currentWord;
    private Word word;

    public Word CreateWord(KeyValuePair<string, string> pair)
    {
        currentWord = pair;
        string w = pair.Key;
        word = new Word();
        for (int i = 0; i < w.Length; i++)
        {
            word.Add(letterSpawner.CreateLetter(w[i]));
        }
        return word;
    }

    public KeyValuePair<string, string> ClearWord()
    {
        word = null;
        letterSpawner.ClearWord();
        return currentWord;
    }
}
