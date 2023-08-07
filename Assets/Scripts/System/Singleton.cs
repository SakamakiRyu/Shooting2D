using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; } = null;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<T>();
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}