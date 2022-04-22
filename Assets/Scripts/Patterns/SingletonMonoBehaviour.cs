using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    private static T instance;
    public static T Instance => instance ?? InitInstance();
    private static T InitInstance()
    {
        CreateInstance();
        instance.Initialize();
        return instance;
    }
    public static void CreateInstance()
    {
        if (!instance) instance = GameObject.FindObjectOfType<T>();
    }
    protected virtual void Initialize()
    {

    }
    protected virtual void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this as T;
    }
}
