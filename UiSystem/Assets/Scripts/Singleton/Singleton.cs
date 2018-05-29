using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Reference types
    protected static T instance;

    /// <summary>
    /// Get the instance of the class.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                    Debug.LogErrorFormat("An instance of {0} is missing in this scene.", typeof(T));
            }

            return instance;
        }
    }
}