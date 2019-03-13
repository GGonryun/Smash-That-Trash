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
        enemy.Target = target;

        Vector3 position = new Vector3(7f, 7f, 0f);

        enemy.Initialize(position, i, enemyHealth);
        EnemySpawned?.Invoke(this, new EnemyEventArgs(enemy));
    }

    public void Despawn(Enemy enemy, int factoryIndex)
    {
        enemyFactories[factoryIndex].Recycle(enemy);
        EnemyQueue.Instance.Remove(enemy);
        EnemyDespawned?.Invoke(this, new EnemyEventArgs(enemy));
    }
}
