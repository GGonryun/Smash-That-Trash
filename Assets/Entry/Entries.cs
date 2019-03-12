using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entries
{
    List<Entry> entries;

    public Entries()
    {
        entries = new List<Entry>();
    }

    public void Add(Entry entry)
    {
        entries.Add(entry);
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
