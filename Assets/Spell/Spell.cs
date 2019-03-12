using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] int power = 0;
    public void SetPower(int power)
    {
        this.power = power;
    }
}
