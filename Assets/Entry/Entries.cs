using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entries : MonoBehaviour
{
    [SerializeField] List<Entry> entries;

    void Awake()
    {
        entries = new List<Entry>();
    }

    private void Start()
    {
        GameManager.Instance.WordCompleted += AddEntry;
    }

    private void OnDisable()
    {
        GameManager.Instance.WordCompleted -= AddEntry;
    }

    void AddEntry(object sender, EntryEventArgs e)
    {
        entries.Add(e.Entry);
    }

    public float Accuracy()
    {
        int success = 0, total = 0;
        foreach(var entry in entries)
        {
            total += entry.Word.Length;
            success += entry.Score;
        }
        return success/(float)total;
    }
}
