using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(IReclaimable))]
public abstract class Projectile : MonoBehaviour, ITargetter<ITargettable>
{
    ITargettable target;
    public ITargettable Target { get => target; set => target = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable enemy = collision.gameObject.GetComponent<IDamageable>();
        enemy?.Damage(1);
        GetComponent<IReclaimable>()?.Reclaim();
    }
}
