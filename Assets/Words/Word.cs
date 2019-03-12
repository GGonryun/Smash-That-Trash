using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains references to the letters used to display the word.
/// </summary>
public class Word
{
    List<Letter> letters;

    public Word()
    {
        letters = new List<Letter>();
    }

    public void Add(Letter letter)
    {
        letters.Add(letter);
    }

    public Letter Get(int i)
    {
        return letters[i];
    }

}
