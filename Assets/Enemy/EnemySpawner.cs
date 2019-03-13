using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] EnemyFactory[] enemyFactories;
    public EnemySpawnedEventHandler EnemySpawned;

    public void Spawn()
    {
        if(enemyFactories == null)
        {
            throw new System.Exception("No enemy factories exist!");
        }
        int i = Random.Range(0, enemyFactories.Length);
        Enemy enemy = enemyFactories[i].Get();
        Vector3 position = Vector3.zero;

        enemy.Initialize(position, enemyFactories[i]);
        EnemySpawned?.Invoke(this, new EnemySpawnedEventArgs(enemy));
    }
}
