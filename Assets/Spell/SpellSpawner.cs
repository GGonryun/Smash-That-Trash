using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Targetting { Closest, Random, Farthest }

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] SpellFactory factory;
    [SerializeField] Targetting targetting = Targetting.Closest;
    private void Start()
    {
        GameManager.Instance.WordCompleted += SpawnSpell;
    }

    public void SpawnSpell(object sender, EntryEventArgs e)
    {
        Spell spell = factory.Get();
        spell.SetPower(e.Entry.Score);
        spell.Target = SelectTarget();
        spell.gameObject.SetActive(true);
    }

    public Enemy SelectTarget()
    {
        switch(targetting)
        {
            case Targetting.Closest:
                return EnemyQueue.Instance.First;
            case Targetting.Farthest:
                return EnemyQueue.Instance.Last;
            case Targetting.Random:
                return EnemyQueue.Instance.Random;
        }
        throw new System.Exception("You have not selected a valid targetting mode!");
    }
}
