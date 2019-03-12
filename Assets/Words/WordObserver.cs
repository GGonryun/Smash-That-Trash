using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordObserver : MonoBehaviour
{

    void Start()
    {
        WordBuilder.Instance.LetterReceived += CheckWord;
    }

    void CheckWord(object sender, InputReceivedEventArgs e)
    {
        if(e.IsSubmission)
        {
            Debug.Log(e.Word);
        }
    }
    
}
