using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordDictionary : MonoBehaviour, IEnumerable<KeyValuePair<string, string>>
{
    Dictionary<string, string> dictionary;

    public string this[string word]
    {
        get
        {
            return dictionary[word]; 
        }
    }

    public WordDictionary(float frequency, int maximumWords)
    {
        dictionary = new Dictionary<string, string>();
        PopulateRandomly(frequency, maximumWords);
    }


    public KeyValuePair<string, string> GetRandom()
    {
        return dictionary.ElementAt(Random.Range(0, dictionary.Count));
    }

    void PopulateRandomly(float frequency, int maximumWords)
    {
        string[] lines = TextLoader.LoadLines("dictionary");
        int i = 0;
        foreach(string line in lines)
        {
            if (frequency >= Random.Range(0f, 1f))
            {
                string word, definition;
                ParseWordDefPair(line, out word, out definition);
                dictionary.Add(word, definition);
                i++;
            }

            if (i > maximumWords)
            {
                break;
            }
        }
    }

    void ParseWordDefPair(string line, out string word, out string definition)
    {
        string[] pair = line.Split(':');
        word = pair[0].Trim(' ', '"');
        definition = pair[1].Trim(' ', '"', ',');
    }

    IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
    {
        foreach(var entry in dictionary)
        {
            yield return entry;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}
