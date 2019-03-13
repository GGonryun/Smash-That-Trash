using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterReader : Singleton<LetterReader>
{
    int index;
    Word word;
    public int Score { get; private set; }

    void OnEnable()
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
        RefreshWord(e.Word);
    }

    private void RefreshWord(Word word)
    {
        index = 0;
        this.word = word;
        Score = 0;
    }
}
