using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueue : Singleton<EnemyQueue>
{
    [SerializeField] List<Enemy> enemies;

    public Enemy First
    {
        get => Select(0);
    }

    public Enemy Random
    {
        get => Select(UnityEngine.Random.Range(0, enemies.Count));
    }

    public Enemy Last
    {
        get => Select(enemies.Count - 1);
    }

    Enemy Select(int index)
    {
        return enemies.Count > 0 ? enemies[index] : null;
    }

    public void Remove(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    void Add(object sender, EnemyEventArgs e)
    {
        enemies.Add(e.Enemy);
    }

    protected override void Awake()
    {
        base.Awake();
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
