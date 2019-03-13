using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
    ITargetter<ITargettable> targettingSystem;
    [SerializeField] float speed;

    void Awake()
    {
        targettingSystem = GetComponent<ITargetter<ITargettable>>();
    }

    void Update()
    {
        if(targettingSystem.Target != null)
        {
            transform.position =
                Vector3.Lerp(
                transform.position,
                targettingSystem.Target.Location,
                Time.deltaTime * speed
                );
        }
        
    }
}
