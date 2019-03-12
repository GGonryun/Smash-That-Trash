using System;
using UnityEngine;

	/// <summary>
	/// Base class for defining singleton MonoBehaviours.
	/// </summary>
	/// <typeparam name="T">The type of the singleton instance.</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
	public static T Instance {
		get {
			return (T)instance;
		}
	}

    static MonoBehaviour instance;

    protected virtual void Awake()
    {
        instance = this; 
    }
}
