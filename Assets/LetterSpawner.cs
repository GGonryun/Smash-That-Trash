using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{

    List<Letter> letters;
    [SerializeField] LetterFactory letterFactory;
    [SerializeField] Transform parent;

    void Awake()
    {
        letters = new List<Letter>();
    }

    void Start()
    {
        Keyboard.Instance.KeyPressed += CreateLetter;
        Keyboard.Instance.Terminate += ClearWord;
    }

    void CreateLetter(object sender, KeyPressedEventArgs e)
    {
        Letter letter = letterFactory.Get();
        letter.Initialize(parent, e.PressedKey);
        letters.Add(letter);
    }

    void ClearWord(object sender, KeyPressedEventArgs e)
    {
        foreach(var letter in letters)
        {
            letterFactory.Recycle(letter);
        }
        letters.Clear();
    }
}
