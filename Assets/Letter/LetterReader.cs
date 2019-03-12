using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterReader : Singleton<LetterReader>
{
    int index;
    Word word;
    public int Score { get; private set; }

    void Start()
    {
        Keyboard.Instance.KeyPressed += CheckLetter;
        GameManager.Instance.WordCreated += RefreshWord;
    }

    void OnDisable()
    {
        Keyboard.Instance.KeyPressed -= CheckLetter;
        GameManager.Instance.WordCreated -= RefreshWord;
    }

    void CheckLetter(object sender, KeyPressedEventArgs e)
    {
        if(index >= word.Length)
        {
            return;
        }

        Letter letter = word[index];
        Debug.Log($"Current Letter {letter.ToString()}, Letter Pressed: {e.PressedKey.ToString().ToLower()}");
        if (Letter.AreEqual(letter, e.PressedKey.ToString().ToLower()[0]))
        {
            Score++;
            letter.SetType(Status.Correct);
        }
        else
        {
            letter.SetType(Status.Wrong);
        }

        index++;
    }

    void RefreshWord(object sender, WordEventArgs e)
    {
        index = 0;
        this.word = e.Word;
        Score = 0;
    }
}
