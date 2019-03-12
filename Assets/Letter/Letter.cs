using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Status { Neutral = 0, Wrong = 1, Correct = 2}

public class Letter : MonoBehaviour
{
    TextMeshProUGUI text;
    void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Initialize(Transform parent, char key)
    {
        if(this.gameObject.activeInHierarchy)
        {
            throw new System.Exception("Cannot init a letter that is already active!");
        }
        this.gameObject.SetActive(true);
        SetType(Status.Neutral);
        this.transform.SetParent(parent, false);
        text.text = key.ToString();
    }

    public void SetType(Status status)
    {
        switch(status)
        {
            case Status.Correct:
                text.color = Color.green;
                break;
            case Status.Wrong:
                text.color = Color.red;
                break;
            case Status.Neutral:
                text.color = Color.white;
                break;
        }
    }
}
