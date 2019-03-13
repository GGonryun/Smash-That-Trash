using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable, ITargettable
{
    public Vector3 Location { get => transform.position; }
    public bool IsActive => gameObject.activeInHierarchy;

    void Awake()
    {
        BaseHealth = CurrentHealth = 1;
    }

    protected override void Destroy()
    {
        Debug.Log("Dead boi");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            IDamageable self = this as IDamageable;
            self.Damage(1);
        }
    }
}
