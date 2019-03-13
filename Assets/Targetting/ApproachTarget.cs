using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
    ITargetter<ITargettable> targettingSystem;
    [SerializeField] float duration;
    public EaseFunctionType easeFunction;

    void Awake()
    {
        targettingSystem = GetComponent<ITargetter<ITargettable>>();
    }

    private void Start()
    {
        if(targettingSystem.Target != null)
        {
            StartCoroutine(Approach(this.transform.position, targettingSystem.Target, duration, easeFunction));
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
                yield return StartCoroutine(Approach(this.transform.position, targettingSystem.Target, duration, easeFunction));
                break;
            }
        }
    }

    private IEnumerator Approach(Vector3 startingPos, ITargettable newPos, float maxDuration, EaseFunctionType easeFunctionSelection)
    {
        //Begin movement.
        float elapsedTime = 0f;
        while (elapsedTime <= maxDuration)
        {
            float ratio = elapsedTime / maxDuration;
            float easedRatio = EaseFunction.Calculate(easeFunctionSelection, ratio);

            transform.localPosition = Vector3.Lerp(startingPos, newPos.Location, easedRatio);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
