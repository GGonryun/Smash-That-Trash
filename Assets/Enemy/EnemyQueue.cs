using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueue : Singleton<EnemyQueue>
{
    [SerializeField] List<Enemy> enemies;

    public Enemy First
    {
        get => enemies[0];
    }

    public Enemy Random
    {
        get => enemies[UnityEngine.Random.Range(0, enemies.Count)];
    }

    public Enemy Last
    {
        get => enemies[enemies.Count - 1];
    }

    public void Remove(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    void Add(object sender, EnemySpawnedEventArgs e)
    {
        enemies.Add(e.Enemy);
    }

    private void Awake()
    {
        enemies = new List<Enemy>();
    }

    private void OnEnable()
    {
        EnemySpawner.Instance.EnemySpawned += Add;
    }

    private void OnDisable()
    {
        EnemySpawner.Instance.EnemySpawned -= Add;

    }


}
