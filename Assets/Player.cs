using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable, ITargettable
{
    public IntEventHandler HealthTracker;
    public Vector3 Location { get => transform.position; }
    public bool IsActive => gameObject.activeInHierarchy;
    [SerializeField] int startingHealth = 5;
    SpellSpawner spawner;
    public SpellSpawner Spawner { get => spawner; }

    void Awake()
    {
        spawner = GetComponent<SpellSpawner>();
    }

    public void Initialize()
    {
        BaseHealth = CurrentHealth = startingHealth;
        spawner.Clear();
        HealthTracker?.Invoke(this, new DataEventArgs<int>(CurrentHealth));
    }

    public override void Destroy()
    {
        GameManager.Instance.EndGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            IDamageable self = this as IDamageable;
            self.Damage(1);
            HealthTracker?.Invoke(this, new DataEventArgs<int>(CurrentHealth));
            enemy.Destroy();
        }
    }
}
