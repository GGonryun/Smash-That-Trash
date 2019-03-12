using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LetterReceivedEventHandler(object sender, LetterReceivedEventArgs e);

public class LetterReceivedEventArgs : System.EventArgs
{
    public string Word { get; private set; }

    public LetterReceivedEventArgs(List<KeyCode> letters)
    {
        StringBuilder builder = new StringBuilder(letters.Count);
        foreach(KeyCode letter in letters)
        {
            builder.Append(letter);
        }
        Word = builder.ToString();
    }
}


public class WordObserver : MonoBehaviour
{
    public LetterReceivedEventHandler LetterReceived;
    List<KeyCode> keysPressed;

    void Start()
    {
        keysPressed = new List<KeyCode>();
        Keyboard.Instance.KeyPressed += LogKeyPress;
    }

    void OnLetterReceived(LetterReceivedEventArgs e)
    {
        LetterReceived?.Invoke(this, e);
    }

    public void LogKeyPress(object sender, KeyPressedEventArgs e)
    {
        keysPressed.Add(e.PressedKey);
        OnLetterReceived(new LetterReceivedEventArgs(keysPressed));
    }
}
