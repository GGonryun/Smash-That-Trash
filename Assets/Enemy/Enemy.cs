using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyFactory parentFactory;
    [SerializeField] int baseHealth = 10;
    int health;
    public int CurrentHealth { get => health; }


    public void Initialize(Vector3 position, EnemyFactory factory)
    {
        parentFactory = factory;
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Reclaim()
    {
        parentFactory.Recycle(this);
    }
}
