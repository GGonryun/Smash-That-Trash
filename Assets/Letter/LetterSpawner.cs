using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : Singleton<LetterSpawner>
{

    List<Letter> letters;
    [SerializeField] LetterFactory letterFactory;
    [SerializeField] Transform parent = null;

    void Awake()
    {
        letters = new List<Letter>();
    }

    void CreateLetter(object sender, KeyPressedEventArgs e)
    {
        Letter letter = letterFactory.Get();
        letter.Initialize(parent, e.PressedKey);
        letters.Add(letter);
        letter.gameObject.name = e.PressedKey.ToString();
    }

    void ClearWord(object sender, KeyPressedEventArgs e)
    {
        int i = letters.Count;
        foreach(var letter in letters)
        {
            letter.transform.SetSiblingIndex(--i);
            letterFactory.Recycle(letter);
        }
        letters.Clear();
    }
}
