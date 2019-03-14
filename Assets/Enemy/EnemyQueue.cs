using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueue : Singleton<EnemyQueue>
{
    [SerializeField] List<Enemy> enemies;
    [SerializeField] Enemy blackHole;
    Transform player;

    public Enemy Closest
    {
        get => SelectEnemy(
            (distance, minimum) => distance < minimum,
            System.Int32.MaxValue
            );
    }

    public Enemy Farthest
    {
        get => SelectEnemy(
            (distance, maximum) => distance < maximum,
            0f
            );
    }

    public Enemy First
    {
        get => SelectEnemy(0);
    }

    public Enemy Random
    {
        get => SelectEnemy(UnityEngine.Random.Range(0, enemies.Count));
    }

    public Enemy Last
    {
        get => SelectEnemy(enemies.Count - 1);
    }

    Enemy SelectEnemy(int index)
    {
        return enemies.Count > 0 ? enemies[index] : blackHole;
    }

    Enemy SelectEnemy(System.Func<float, float, bool> comparitor, float startingValue)
    {
        float cached = startingValue;
        Enemy selection = blackHole;
        if (enemies.Count > 0)
        {
            foreach (var enemy in enemies)
            {
                float distance = Mathf.Abs(Vector3.Distance(player.position, enemy.gameObject.transform.position));
                if (comparitor(distance, cached))
                {
                    cached = distance;
                    selection = enemy;
                }
            }
        }
        return selection;
    }

    public void Remove(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    void Add(object sender, DataEventArgs<Enemy> e)
    {
        enemies.Add(e.Data);
    }

    protected override void Awake()
    {
        base.Awake();
        enemies = new List<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        EnemySpawner.Instance.EnemySpawned += Add;
    }

    private void OnDisable()
    {
        EnemySpawner.Instance.EnemySpawned -= Add;
    }
}
