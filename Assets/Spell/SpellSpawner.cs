using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] SpellFactory factory;

    private void Start()
    {
        GameManager.Instance.WordCompleted += SpawnSpell;
    }

    public void SpawnSpell(object sender, EntryEventArgs e)
    {
        Spell spell = factory.Get();
        spell.SetPower(e.Entry.Score);
        spell.gameObject.SetActive(true);
    }
}
