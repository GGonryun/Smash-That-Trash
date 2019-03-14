using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntriesDisplay : MonoBehaviour
{
    public DefinitionDisplay display;
    public EntriesFactory factory;
    public TMPro.TextMeshProUGUI accuracy;
    public Transform folder;
    List<EntryButton> buttons;

    void Awake()
    {
        buttons = new List<EntryButton>();
    }

    public void Initialize(Entries entries)
    {
        accuracy.text = $"{entries.Accuracy()*100f:F2}%";
        foreach(var entry in entries)
        {
            EntryButton entryDisplay = factory.Get();
            entryDisplay.transform.parent = folder;
            entryDisplay.gameObject.SetActive(true);
            entryDisplay.Initialize(display, entry.Word, entry.Definition, entry.Score);
        }
    }

    public void Clear()
    {
        if(buttons != null && buttons.Count > 0)
        {
            foreach (var button in buttons)
            {
                factory.Recycle(button);
            }
            buttons.Clear();
        }
        
    }
}
