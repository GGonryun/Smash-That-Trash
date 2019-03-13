using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Targetting { Closest, Random, Farthest }

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] SpellFactory factory;
    [SerializeField] Targetting targetting = Targetting.Closest;
    private void Start()
    {
        LetterReader.Instance.CorrectLetterPressed += SpawnSpell;
    }

    void SpawnSpell(object sender, LetterEventArgs e)
    {
        Spell spell = factory.Get();
        spell.Initialize(this, e.Letter.transform.position);
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

    public void Reclaim(Spell spell)
    {
        factory.Recycle(spell);
    }
}
