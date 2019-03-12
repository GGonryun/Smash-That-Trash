using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void KeyPressedEventHandler(object sender, KeyPressedEventArgs e);

public class KeyPressedEventArgs : System.EventArgs
{
    public KeyCode PressedKey { get; private set; }
    public KeyPressedEventArgs(KeyCode pressedKey)
    {
        this.PressedKey = pressedKey;
    }
}

public class Keyboard : Singleton<Keyboard>
{

    [SerializeField] List<KeyCode> keys = new List<KeyCode>();
    [SerializeField] KeyCode terminationKey = KeyCode.Space;

    void Update()
    {
        InputLetter();
        TerminateLetter();
    }

    public KeyPressedEventHandler KeyPressed;
    public KeyPressedEventHandler Terminate;

    void OnTerminate(KeyPressedEventArgs e)
    {
        Terminate.Invoke(this, e);
    }

    void OnKeyPressed(KeyPressedEventArgs e)
    {
        KeyPressed?.Invoke(this, e);
    }

   

    void TerminateLetter()
    {
        if (Input.GetKeyDown(terminationKey))
        {
            OnTerminate(new KeyPressedEventArgs(terminationKey));
        }
    }

    void InputLetter()
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                OnKeyPressed(new KeyPressedEventArgs(key));
            }
        }
    }
}
