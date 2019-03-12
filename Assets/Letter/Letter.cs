using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        this.transform.SetParent(parent, false);
        text.text = key.ToString();
    }
}
