using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryButton : MonoBehaviour
{
    public DefinitionDisplay displayDefinition;
    public Text wordDisplay;
    public Button wordButton;
    public string definition;
    public string score;


    public void Initialize(DefinitionDisplay definitionDisplayer, string word, string definition, int score)
    {
        displayDefinition = definitionDisplayer;
        wordDisplay.text = word;
        this.definition = definition;
        this.score = score.ToString();
        wordButton.onClick.AddListener(Display);
    }


    public void Display()
    {
        displayDefinition.Display(wordDisplay.text, definition, score);
    }
}
