using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : Singleton<Keyboard>
{

    [SerializeField] List<KeyCode> keys = new List<KeyCode>();
    [SerializeField] KeyCode terminationKey = KeyCode.Space;
    new bool enabled = false;
    public KeyPressedEventHandler KeyPressed;
    public KeyPressedEventHandler Terminate;
    public void Disable() => enabled = false;
    public void Enable() => enabled = true;


    void Update()
    {
        if (enabled)
        {
            InputLetter();
            TerminateLetter();
        }
    }

    void OnTerminate(KeyPressedEventArgs e)
    {
        Terminate?.Invoke(this, e);
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
