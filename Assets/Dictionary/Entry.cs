using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry
{
    public string Word { get; private set; }
    public string Definition { get; private set; }
    public int Score { get; private set;}

    public Entry(string word, string definition, int score)
    {
        Word = word;
        Definition = definition;
        Score = score;
    }

}
