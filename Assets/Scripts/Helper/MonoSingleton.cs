using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour
    where T : MonoSingleton<T>
{
    public static T instance;
    public static T i
    {
        get
        {
            instance ??= GameObject.FindObjectOfType<T>();
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    protected void Awake()
    {
        i = (T)this;
    }
}
