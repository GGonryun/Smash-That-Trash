using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Damageable : MonoBehaviour, IDamageable
{

    int baseHealth = 10;
    int currentHealth = 10;
    public int CurrentHealth { get => currentHealth; protected set => currentHealth = value; }
    public int BaseHealth { get => baseHealth; protected set => baseHealth = value; }

    void IDamageable.Damage(int i)
    {
        currentHealth -= i;
        if (currentHealth <= 0)
        {
            Destroy();
        }
    }

    protected abstract void Destroy();
}
