using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] EnemyFactory[] enemyFactories;
    [SerializeField] int enemyHealth = 10;
    ITargettable target = null;
    public EnemySpawnedEventHandler EnemySpawned;
    

    protected override void Awake()
    {
        base.Awake();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();
    }

    public void Spawn()
    {
        if(enemyFactories == null)
        {
            throw new System.Exception("No enemy factories exist!");
        }
        int i = Random.Range(0, enemyFactories.Length);
        Enemy enemy = enemyFactories[i].Get();
        Vector3 position = Vector3.zero;

        enemy.Target = target;
        enemy.Initialize(position, enemyFactories[i], enemyHealth);
        EnemySpawned?.Invoke(this, new EnemySpawnedEventArgs(enemy));
    }
}
