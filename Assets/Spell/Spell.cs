using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, ITargetter<ITargettable>, ISuicidal
{
    SpellFactory factory;
    int power = 0;
    ITargettable target;
    public ITargettable Target { get => target; set => target = value; }

    void OnEnable()
    {
        EnemySpawner.Instance.EnemySpawned += ReTarget;
    }

    void OnDisable()
    {
        EnemySpawner.Instance.EnemySpawned -= ReTarget;
    }

    public void ReTarget(object sender, EnemySpawnedEventArgs e)
    {
        if(target == null)
        {
            target = e.Enemy as ITargettable;
        }
    }

    public void Initialize(SpellFactory factory, Vector3 position, int power)
    {
        this.factory = factory;
        this.transform.position = position;
        this.power = power;
    }

}
