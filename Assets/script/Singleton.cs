using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T>:MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance=FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject Object= new GameObject();
                    Object.name=typeof(T).Name;
                    instance=Object.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
         Destroy(gameObject);
        }
    
    }

   

}
