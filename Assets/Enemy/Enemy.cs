using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable, ITargetter<ITargettable>, ITargettable
{
    int factoryIndex;
    [SerializeField] ITargettable target;
    [SerializeField] int startingHealth;
    public ITargettable Target { get => target; set => target = value; }
    public Vector3 Location => transform.position;

    public bool IsActive => gameObject.activeInHierarchy;

    public void Initialize(Vector3 position, int factoryIndex)
    {
        BaseHealth = CurrentHealth = startingHealth;
        this.factoryIndex = factoryIndex;
        transform.position = position;
        gameObject.SetActive(true);
    }

    public override void Destroy() => EnemySpawner.Instance.Despawn(this, factoryIndex);




}
