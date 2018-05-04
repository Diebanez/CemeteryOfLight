using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : Component{
    private static T m_Instance = default(T);

    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {
                T[] instances = GameObject.FindObjectsOfType<T>();

                if (instances.Length == 1)
                {
                    //ricollega l'unica istanza
                    m_Instance = instances[0];
                }
                else
                {
                    //se ci sono, distruggiamoli
                    for (int i = 0; i < instances.Length; i++)
                    {
                        Destroy(instances[i].gameObject);
                    }

                    //creaiamo la nuova istanza
                    GameObject go = new GameObject();
                    go.name = typeof(T).Name;
                    m_Instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                }
            }
            return m_Instance;
        }
    }
}
