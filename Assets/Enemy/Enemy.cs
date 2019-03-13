using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITargetter<ITargettable>, ITargettable
{
    EnemyFactory parentFactory;
    int baseHealth = 10;
    int currentHealth = 10;
    public int CurrentHealth { get => currentHealth; }
    public int BaseHealth { get => baseHealth; }

    [SerializeField] ITargettable target;    
    public ITargettable Target { get => target; set => target = value; }
    public Vector3 Location => transform.position;

    public void Initialize(Vector3 position, EnemyFactory factory, int Health)
    {
        baseHealth = currentHealth = Health;
        parentFactory = factory;
        transform.position = position;
        gameObject.SetActive(true);

    }

    public void Reclaim()
    {
        parentFactory.Recycle(this);
    }
}
