using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Projectile, IReclaimable
{
    SpellSpawner spawner;

    public void LocateTarget()
    {
        if (Target == null || !Target.IsActive)
        {
            Target = spawner.SelectTarget();
        }
    }

    void Update()
    {
        LocateTarget();
    }

    public void Initialize(SpellSpawner spawner, Vector3 position)
    {
        this.spawner = spawner;
        this.transform.position = position;
    }

    public void Reclaim()
    {
        Target = null;
        AudioManager.Instance.PlaySound("Impact");
        spawner.Reclaim(this);
    }


}
