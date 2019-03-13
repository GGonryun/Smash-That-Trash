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

    private void Start()
    {
        if(targettingSystem.Target != null)
        {
            StartCoroutine(Approach(targettingSystem.Target));
        }
        else
        {
            StartCoroutine(AwaitTarget());
        }
    }

    private IEnumerator AwaitTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(.25f);
            if(targettingSystem.Target != null)
            {
                yield return StartCoroutine(Approach(targettingSystem.Target));
                break;
            }
        }
    }

    private IEnumerator Approach(ITargettable target)
    {
        //Begin movement.
        while (Vector3.Distance(transform.position, target.Location) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.Location, Time.deltaTime * speed);
            yield return null;
        }
        Debug.Log("We've arrived.");
    }
}
