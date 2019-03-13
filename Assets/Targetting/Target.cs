using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ITargettable
{
    public Vector3 Location { get => transform.position; }
    public bool IsActive => gameObject.activeInHierarchy;
}
