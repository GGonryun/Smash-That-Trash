using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextLoader
{
    private static string Load(string filePath)
    {
        TextAsset textFile = Resources.Load(filePath) as TextAsset;
        return textFile.text;
    }

    public static string[] LoadLines(string filePath)
    {
        string text = Load(filePath);
        string[] lines = text.Split(new[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        return lines;
    }

}
