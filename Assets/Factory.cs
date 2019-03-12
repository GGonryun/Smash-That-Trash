using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<T> : ScriptableObject where T : MonoBehaviour
{
    public T template;

    [System.NonSerialized] Stack<T> objectPool;
    private Stack<T> ObjectPool
    {
        get
        {
            if(objectPool == null)
            {
                objectPool = new Stack<T>();
            }
            return objectPool;
        }
    }

    public virtual T Get()
    {

        if (ObjectPool.Count > 0)
        {
            return ObjectPool.Pop();
        }
        else
        {
            return Instantiate(template) as T;
        }
    }


    public virtual void Recycle(T obj)
    {
        ObjectPool.Push(obj);
        obj.gameObject.SetActive(false);
    }

}
