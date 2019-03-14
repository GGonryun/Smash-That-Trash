using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefinitionDisplay : MonoBehaviour
{
    public TextMeshProUGUI definition;
    public TextMeshProUGUI score;
    public TextMeshProUGUI word;

    public void Display(string word, string definition, string score)
    {
        this.word.text = word;
        this.definition.text = definition;
        this.score.text = score;
    }
}
