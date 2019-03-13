using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
    ITargetter<ITargettable> targettingSystem;
    [SerializeField] float speed = 1f;

    void Awake()
    {
        targettingSystem = GetComponent<ITargetter<ITargettable>>();
    }

    private void Update()
    {
        if (targettingSystem.Target != null && targettingSystem.Target.IsActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, targettingSystem.Target.Location, Time.deltaTime * speed);
        }
    }
}
