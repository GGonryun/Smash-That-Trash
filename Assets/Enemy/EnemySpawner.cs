using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] EnemyFactory[] enemyFactories;
    [SerializeField] int enemyHealth = 10;
    ITargettable target = null;
    public EnemyEventHandler EnemySpawned;
    public EnemyEventHandler EnemyDespawned;

    [SerializeField] Vector2 spawnPoint;
    [SerializeField] [Range(0, 20f)] float horizontalSpawnRange;
    [SerializeField] [Range(0, 20f)] float verticalSpawnRange;

    protected override void Awake()
    {
        base.Awake();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<ITargettable>();
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

        enemy.Initialize(position, i, enemyHealth);
        OnEnemySpawned(new EnemyEventArgs(enemy));
    }

    public void Despawn(Enemy enemy, int factoryIndex)
    {
        enemyFactories[factoryIndex].Recycle(enemy);
        EnemyQueue.Instance.Remove(enemy);
        OnEnemyDespawned(new EnemyEventArgs(enemy));
    }

    Vector2 SelectRandomPos()
    {
        Vector2 spawn = spawnPoint + new Vector2(
            Random.Range(-horizontalSpawnRange, horizontalSpawnRange),
            Random.Range(-verticalSpawnRange, verticalSpawnRange)
            );

        return spawn;
    }

    void OnEnemySpawned(EnemyEventArgs e)
    {
        EnemySpawned?.Invoke(this, e);
    }

    void OnEnemyDespawned(EnemyEventArgs e)
    {
        EnemyDespawned?.Invoke(this, e);
    }
}
