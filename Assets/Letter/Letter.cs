using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Status { Neutral = 0, Wrong = 1, Correct = 2 }

public class Letter : MonoBehaviour
{
    TextMeshProUGUI text;
    char character;
    void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Initialize(Transform parent, char key)
    {
        if (this.gameObject.activeInHierarchy)
        {
            throw new System.Exception("Cannot init a letter that is already active!");
        }
        character = key;
        this.gameObject.SetActive(true);
        SetType(Status.Neutral);
        this.transform.SetParent(parent, false);
        text.text = character.ToString();
    }

    private IEnumerator Bounce(float maxTime, float height)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        Vector3 maxHeight = transform.position;
        maxHeight.y += height;
        while (elapsedTime <= maxTime)
        {
            transform.position = Vector3.Lerp(transform.position, maxHeight, elapsedTime / maxTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void SetType(Status status)
    {

        switch (status)
        {
            case Status.Correct:
                text.color = Color.green;
                StartCoroutine(Bounce(1f, .15f));
                break;
            case Status.Wrong:
                text.color = Color.red;
                StartCoroutine(Bounce(1f, -.15f));
                break;
            case Status.Neutral:
                text.color = Color.white;
                break;
        }
    }

    public override string ToString()
    {
        return character.ToString();
    }
    public static bool AreEqual(Letter a, Letter b)
    {
        return a.character.Equals(b.character);
    }
    public static bool AreEqual(Letter a, char b)
    {
        return a.character.Equals(b);
    }
}
