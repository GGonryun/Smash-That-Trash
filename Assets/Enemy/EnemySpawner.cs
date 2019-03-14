using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] EnemyFactory[] enemyFactories;
    ITargettable target = null;
    public EnemyEventHandler EnemySpawned;
    public EnemyEventHandler EnemyDespawned;

    [SerializeField] Vector2 spawnPoint;
    [SerializeField] [Range(0, 20f)] float horizontalSpawnRange = 10f;
    [SerializeField] [Range(0, 20f)] float verticalSpawnRange = 1f;

    List<Enemy> enemies;

    protected override void Awake()
    {
        base.Awake();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<ITargettable>();
        enemies = new List<Enemy>();
    }

    public void Spawn()
    {
        if(enemyFactories == null)
        {
            throw new System.Exception("No enemy factories exist!");
        }
        int i = Random.Range(0, enemyFactories.Length);
        Enemy enemy = enemyFactories[i].Get();
        enemy.Target = target;

        Vector3 position = SelectRandomPos();

        enemy.Initialize(position, i);
        enemies.Add(enemy);
        OnEnemySpawned(new DataEventArgs<Enemy>(enemy));
    }

    public void Despawn(Enemy enemy, int factoryIndex)
    {
        enemyFactories[factoryIndex].Recycle(enemy);
        EnemyQueue.Instance.Remove(enemy);
        OnEnemyDespawned(new DataEventArgs<Enemy>(enemy));
    }

    public void Clear()
    {
        foreach(var enemy in enemies)
        {
            enemy.Destroy();
        }
        enemies.Clear();
    }

    Vector2 SelectRandomPos()
    {
        Vector2 spawn = spawnPoint + new Vector2(
            Random.Range(-horizontalSpawnRange, horizontalSpawnRange),
            Random.Range(-verticalSpawnRange, verticalSpawnRange)
            );

        return spawn;
    }

    void OnEnemySpawned(DataEventArgs<Enemy> e)
    {
        EnemySpawned?.Invoke(this, e);
    }

    void OnEnemyDespawned(DataEventArgs<Enemy> e)
    {
        EnemyDespawned?.Invoke(this, e);
    }
}
