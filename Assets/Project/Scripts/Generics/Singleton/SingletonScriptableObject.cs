using System.Linq;
using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T m_instance = null;
    public static T instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = Resources.LoadAll<T>("").FirstOrDefault();                
            }
            return m_instance;
        }
    }
}