using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] int power = 0;
    Enemy target;

    public void SetTarget(Enemy target)
    {
        this.target = target;
    }

    public void SetPower(int power)
    {
        this.power = power;
    }
}
