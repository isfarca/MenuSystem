﻿using UnityEngine;

public class Menu<T> : Menu where T : Menu<T>
{
    // Reference types
    private static T instance;

    /// <summary>
    /// Initialize the instance.
    /// </summary>
    protected virtual void Awake()
    {
        // Initialize the menu instance.
        instance = (T)this;
    }

    /// <summary>
    /// Set nulls.
    /// </summary>
    protected virtual void OnDestroy()
    {
        // By destroying the menus, than set the instance of null.
        instance = null;
    }

    /// <summary>
    /// Starting the instance of menu.
    /// </summary>
    protected static void Open()
    {
        // Create or Activate a menu instance and open the menu.
        if (instance == null)
            MenuManager.Instance.CreateInstance<T>();
        else
            instance.gameObject.SetActive(true);

        MenuManager.Instance.OpenMenu(instance);
    }

    /// <summary>
    /// Closing the instance of menu.
    /// </summary>
    protected static void Close()
    {
        // Close the menu by instance, else throw exception.
        if (instance == null)
        {
            Debug.LogErrorFormat("No menu of type {0} is currently open.", typeof(T));

            return;
        }

        MenuManager.Instance.ClosedMenu(instance);
    }

    /// <summary>
    /// By pressing back, start the closing of menu.
    /// </summary>
    public override void OnBackPressed()
    {
        Close();
    }

    /// <summary>
    /// Get/Set the instance of the menu class.
    /// </summary>
    public T Instance
    {
        get { return instance; }
        private set { instance = value; }
    }
}

public abstract class Menu : MonoBehaviour
{
    // Value types
    public bool destroyWhenClosed = true;
    public bool disableMenuUnderneath = true;

    public abstract void OnBackPressed();
}