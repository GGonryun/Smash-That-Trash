using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, ITargetter<ITargettable>
{
    int power = 0;
    ITargettable target;
    public ITargettable Target { get => target; set => target = value; }

    public void Initialize(Vector3 position, int power)
    {
        this.transform.position = position;
        this.power = power;
    }

}
