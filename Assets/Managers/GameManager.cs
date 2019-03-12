using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] float frequency = .01f;
    [SerializeField] int maximumWords = 100;
    WordDictionary dictionary;

    void Awake()
    {
        dictionary = new WordDictionary(frequency, maximumWords);
        foreach(KeyValuePair<string, string> entry in dictionary)
        {
            Debug.Log(entry.Key);
        }
    }
}
