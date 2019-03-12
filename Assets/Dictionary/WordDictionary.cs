using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordDictionary : MonoBehaviour
{
    Dictionary<string, string> dictionary;

    public string this[string word]
    {
        get
        {
            return dictionary[word]; 
        }
    }

    public WordDictionary(int frequency, int maximumWords)
    {
        dictionary = new Dictionary<string, string>();
        PopulateRandomly(frequency, maximumWords);
    }

    public KeyValuePair<string, string> GetRandom()
    {
        return dictionary.ElementAt(Random.Range(0, dictionary.Count));
    }

    public void PopulateRandomly(int frequency, int maximumWords)
    {
        string[] lines = TextLoader.LoadLines("dictionary");
        int i = 0;
        foreach(string line in lines)
        {
            if(i >= maximumWords)
            {
                break;
            }

            if (frequency/10f >= Random.Range(0f, 1f))
            {
                i++;
                string[] pair = line.Split(':');
                string word = pair[0].Trim(' ', '"');
                string definition = pair[1].Trim(' ', '"', ',');
                Debug.Log($"Word: {word}, Definition: {definition}");
                dictionary.Add(word, definition);
            }

        }
    }
}
