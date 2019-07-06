using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;

    public static T Instance
    {
        get { return instance; }

        set
        {
            if (null == instance)
            {
                instance = value;
                DontDestroyOnLoad(instance.gameObject);
            }
            else if (instance != null)
            {
                Destroy(value.gameObject);
            }
        }
    }

    public void Awake()
    {
        Instance=this as T;
    }
}
