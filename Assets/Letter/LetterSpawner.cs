using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{

    List<Letter> letters;
    [SerializeField] LetterFactory letterFactory;
    [SerializeField] Transform parent = null;

    void Awake()
    {
        letters = new List<Letter>();
    }

    public void CreateLetter(KeyCode key)
    {
        CreateLetter(key.ToString()[0]);
    }

    public void CreateLetter(char key)
    {
        Letter letter = letterFactory.Get();
        letter.Initialize(parent, key);
        letters.Add(letter);
        letter.gameObject.name = key.ToString();
    }

    public void ClearWord()
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
