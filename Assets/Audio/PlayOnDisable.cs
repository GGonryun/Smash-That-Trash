using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnDisable : MonoBehaviour
{

    public string[] sounds;

    public void Start()
    {
        EnemySpawner.Instance.EnemyDespawned += PlaySound;
    }

    public void OnDisable()
    {
        EnemySpawner.Instance.EnemyDespawned -= PlaySound;
    }

    public void PlaySound(object sender, DataEventArgs<Enemy> e)
    {
        AudioManager.Instance.PlaySound(sounds[e.Data.FactoryIndex]);
    }

}
