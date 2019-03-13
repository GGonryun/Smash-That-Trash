using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
    ITargettable target;
    [SerializeField] float speed;

    void Awake()
    {
        target = GetComponent<ITargetter<ITargettable>>().Target;
    }

    void Update()
    {
        transform.position = 
            Vector3.Lerp(
            transform.position, 
            target.Location, 
            Time.deltaTime * speed
            );
    }
}
