using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void InputReceivedEventHandler(object sender, InputReceivedEventArgs e);

public class InputReceivedEventArgs : System.EventArgs
{
    public bool IsSubmission { get; private set; }
    public string Word { get; private set; }

    public InputReceivedEventArgs(List<KeyCode> letters, bool isSubmission = false)
    {
        StringBuilder builder = new StringBuilder(letters.Count);
        foreach(KeyCode letter in letters)
        {
            builder.Append(letter);
        }
        Word = builder.ToString();

        IsSubmission = isSubmission;
    }
}

public class WordBuilder : Singleton<WordBuilder>
{
    public InputReceivedEventHandler LetterReceived;
    
    List<KeyCode> keysPressed;

    void Start()
    {
        keysPressed = new List<KeyCode>();
        Keyboard.Instance.KeyPressed += LogKeyPress;
        Keyboard.Instance.Terminate += TerminateWord;
    }

    void OnInputReceived(InputReceivedEventArgs e)
    {
        LetterReceived?.Invoke(this, e);
    }

    void TerminateWord(object sender, KeyPressedEventArgs e)
    {
        OnInputReceived(new InputReceivedEventArgs(keysPressed, true));
        keysPressed.Clear();
    }

    void LogKeyPress(object sender, KeyPressedEventArgs e)
    {
        keysPressed.Add(e.PressedKey);
        OnInputReceived(new InputReceivedEventArgs(keysPressed, false));
    }
}
