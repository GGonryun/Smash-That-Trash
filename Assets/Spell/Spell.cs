using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, ITargetter<Enemy>
{
    int power = 0;
    Enemy target;
    public Enemy Target { get => target; set => target = value; }

    public void SetPower(int power)
    {
        this.power = power;
    }

}
