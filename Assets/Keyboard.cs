﻿using System;
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
    
    /// <summary>
    /// This key determines which key will be used to terminate a string.
    /// </summary>
    public KeyCode TerminationKey { get => terminationKey; }

    public KeyPressedEventHandler KeyPressed;
    void OnKeyPressed(KeyPressedEventArgs e)
    {
        KeyPressed?.Invoke(this, e);
    }

    void Update()
    {
        foreach (KeyCode key in keys)
        {
            if(Input.GetKeyDown(key))
            {
                OnKeyPressed(new KeyPressedEventArgs(key));
            }
        }
    }

}
