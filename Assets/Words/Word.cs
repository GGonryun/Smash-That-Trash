using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains references to the letters used to display the word.
/// </summary>
public class Word
{
    List<Letter> letters;

    public int Length { get => letters.Count; }

    public Letter this[int i]
    {
        get => letters[i];
    }

    public Word()
    {
        letters = new List<Letter>();
    }

    public void Add(Letter letter)
    {
        letters.Add(letter);
    }

    

}
