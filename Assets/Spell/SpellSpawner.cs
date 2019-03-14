using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Targetting { Closest, Farthest, First, Last, Random }

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] SpellFactory factory;
    [SerializeField] Targetting targetting = Targetting.Closest;
    List<Spell> spells;

    void Awake()
    {
        spells = new List<Spell>();
    }
    void OnEnable()
    {
        LetterReader.Instance.CorrectLetterPressed += SpawnSpell;
    }

    void OnDisable()
    {
        LetterReader.Instance.CorrectLetterPressed -= SpawnSpell;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetting = Targetting.Closest;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetting = Targetting.Farthest;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetting = Targetting.First;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            targetting = Targetting.Last;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            targetting = Targetting.Random;
        }
    }
    void SpawnSpell(object sender, LetterEventArgs e)
    {
        Spell spell = factory.Get();
        spells.Add(spell);
        spell.Initialize(this, e.Letter.transform.position);
        spell.Target = SelectTarget();
        spell.gameObject.SetActive(true);
    }
    public Enemy SelectTarget()
    {
        switch(targetting)
        {
            case Targetting.Closest:
                return EnemyQueue.Instance.Closest;
            case Targetting.Farthest:
                return EnemyQueue.Instance.Farthest;
            case Targetting.First:
                return EnemyQueue.Instance.First;
            case Targetting.Last:
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

    public void Clear()
    {
        foreach(Spell spell in spells)
        {
            Reclaim(spell);
        }
        spells.Clear();
    }
}
