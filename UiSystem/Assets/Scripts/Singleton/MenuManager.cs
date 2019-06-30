using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    // Menus.
    private readonly Stack<Menu> menuStack = new Stack<Menu>();
    [SerializeField] private Menu[] menuPrefabs;
    
    /// <summary>
    /// Initializing.
    /// </summary>
    private void Start()
    {
        // Start the main menu.
        MainMenu.Show();
    }

    /// <summary>
    /// Create a instance of menu.
    /// </summary>
    /// <typeparam name="T">Type of the menu.</typeparam>
    public void CreateInstance<T>() where T : Menu
    {
        // Declare variables
        var prefab = GetPrefab<T>();

        // Instantiate new instance of menu manager.
        Instantiate(prefab, transform);
    }

    /// <summary>
    /// Open the menu by instance.
    /// </summary>
    /// <param name="instance">The instance of the menu.</param>
    public void OpenMenu(Menu instance)
    {
        // Opening menu.
        if (menuStack.Count > 0)
        {
            if (instance.disableMenuUnderneath)
            {
                foreach (var menu in menuStack)
                {
                    var canvasGroup = menu.GetComponent<CanvasGroup>();

                    if (canvasGroup != null)
                    {
                        canvasGroup.interactable = false;
                    }
                    else
                    {
                        menu.gameObject.SetActive(false);
                    }

                    if (menu.disableMenuUnderneath)
                    {
                        break;
                    }
                }
            }

            // Get the first and last menu.
            var topCanvas = instance.GetComponent<Canvas>();
            var prevCanvas = menuStack.Peek().GetComponent<Canvas>();

            // Sorting all menus.
            topCanvas.sortingOrder = prevCanvas.sortingOrder + 1;
        }

        // Push the above instance.
        menuStack.Push(instance);
    }

    /// <summary>
    /// Close the menu by instance.
    /// </summary>
    /// <param name="instance">The instance of the menu.</param>
    public void ClosedMenu(Menu instance)
    {
        // By no menus, output the error.
        if (menuStack.Count <= 0)
        {
            Debug.LogErrorFormat("Stack is empty! {0} cannot be closed.", instance.GetType());

            return;
        }

        // When instance unequal the top of the stack, than output the error.
        if (menuStack.Peek() != instance)
        {
            Debug.LogErrorFormat("{0} is not the top menu.", instance.GetType());

            return;
        }

        // Else, closing the menu.
        CloseTopMenu();
    }

    /// <summary>
    /// Closing the menu of the top of the stack.
    /// </summary>
    private void CloseTopMenu()
    {
        // Get top menu instance.
        var instance = menuStack.Pop();
        
        // Destroy the menu.
        if (instance.destroyWhenClosed)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance.gameObject.SetActive(false);
        }

        // Activate all canvas.
        foreach (var menu in menuStack)
        {
            var canvasGroup = menu.GetComponent<CanvasGroup>();

            if (canvasGroup != null)
            {
                canvasGroup.interactable = true;
            }
            else
            {
                menu.gameObject.SetActive(true);
            }

            if (menu.disableMenuUnderneath)
            {
                break;
            }
        }
    }

    /// <summary>
    /// Getting all menu prefabs.
    /// </summary>
    /// <typeparam name="T">Type of the menu.</typeparam>
    /// <returns>Missing reference exception.</returns>
    private T GetPrefab<T>() where T : Menu
    {
        // Check, if you have menu prefabs.
        foreach (var menu in menuPrefabs)
        {
            var prefab = menu as T;

            if (prefab != null)
            {
                return prefab;
            }
        }

        // By doesn't menu prefabs, output the error.
        throw new MissingReferenceException("No prefab of type " + typeof(T) + " found!");
    }
}