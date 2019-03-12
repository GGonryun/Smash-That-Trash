using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordObserver : MonoBehaviour
{

    void Start()
    {
        WordBuilder.Instance.LetterReceived += CheckWord;
    }

    void CheckWord(object sender, LetterReceivedEventArgs e)
    {
        Debug.Log(e.Word);
    }
    
}
