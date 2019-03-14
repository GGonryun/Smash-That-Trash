using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefinitionDisplay : MonoBehaviour
{
    public TextMeshProUGUI definition;
    public TextMeshProUGUI score;

    public void Display(string definition, string score)
    {
        this.definition.text = definition;
        this.score.text = score;
    }
}
