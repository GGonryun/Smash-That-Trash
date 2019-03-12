using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBuilder : Singleton<WordBuilder>
{
    [SerializeField] LetterSpawner letterSpawner;
    private KeyValuePair<string, string> currentWord;

    public void CreateWord(KeyValuePair<string, string> pair)
    {
        string word = pair.Key;
        for (int i = 0; i < word.Length; i++)
        {
            letterSpawner.CreateLetter(word[i]);
        }
    }

    public KeyValuePair<string, string> ClearWord()
    {
        letterSpawner.ClearWord();
        return currentWord;
    }
}
