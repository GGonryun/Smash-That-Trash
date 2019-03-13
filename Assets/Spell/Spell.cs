using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Projectile, IReclaimable, ITargetter<ITargettable>
{
    SpellSpawner spawner;
    ITargettable target;
    public ITargettable Target { get => target; set => target = value; }

    void OnEnable()
    {
    }

    void OnDisable()
    {
    }
    void Update()
    {
        if(target == null || !target.IsActive)
        {
            Debug.Log("no target");
            target = spawner.SelectTarget();
        }
    }
    public void LocateTarget(object sender, EnemyEventArgs e)
    {
        if (target == null || !target.IsActive)
        {
            target = spawner.SelectTarget();
        }
    }


    public void Initialize(SpellSpawner spawner, Vector3 position)
    {
        this.spawner = spawner;
        this.transform.position = position;
    }

    public void Reclaim()
    {
        target = null;
        spawner.Reclaim(this);
    }


}
