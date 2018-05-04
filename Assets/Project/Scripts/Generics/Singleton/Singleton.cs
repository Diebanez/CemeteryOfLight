using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class that represent a singleton
/// </summary>
/// <typeparam name="T">class that have to be singleton</typeparam>
public class Singleton<T> : MonoBehaviour where T : Component{

    private static T m_Instance = default(T);

    /// <summary>
    /// Instance of the singleton
    /// </summary>
    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {
                //verifichiamo che non ci siano in scena oggetti T
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
                }
            }

            return m_Instance;
        }
    }

}
