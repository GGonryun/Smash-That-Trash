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

public class KeyboardReader : MonoBehaviour
{
    public KeyPressedEventHandler KeyPressed;

    public void OnKeyPressed(KeyPressedEventArgs e)
    {
        KeyPressed?.Invoke(this, e);
    }
}
