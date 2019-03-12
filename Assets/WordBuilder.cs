using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LetterReceivedEventHandler(object sender, LetterReceivedEventArgs e);

public class LetterReceivedEventArgs : System.EventArgs
{
    public bool IsSubmission { get; private set; }
    public string Word { get; private set; }

    public LetterReceivedEventArgs(List<KeyCode> letters, bool isSubmission = false)
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
    public LetterReceivedEventHandler LetterReceived;
    List<KeyCode> keysPressed;
    [SerializeField] KeyCode terminationKey = KeyCode.Space;

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
        KeyCode key = e.PressedKey;

        if(key == terminationKey)
        {
            OnLetterReceived(new LetterReceivedEventArgs(keysPressed, true));
            keysPressed.Clear();
        }
        else
        {
            keysPressed.Add(e.PressedKey);
            OnLetterReceived(new LetterReceivedEventArgs(keysPressed));
        }
    }
}
