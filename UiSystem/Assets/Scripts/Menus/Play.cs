using UnityEngine;

public class Play : Menu<Play>
{
    // Reference types.
    private GameObject terrain;
    private GameObject audioSource;
    private GameObject frequenceCubes;

    /// <summary>
    /// Game object initialization.
    /// </summary>
    private void OnEnable()
    {
        // Terrain.
        terrain = GameObject.Find("Terrain");
        terrain.SetActive(false);

        // AudioSource.
        audioSource = GameObject.Find("AudioPeer");
        audioSource.SetActive(false);

        // Frequences.
        frequenceCubes = GameObject.Find("Frequences");
        frequenceCubes.SetActive(false);
    }

    /// <summary>
    /// Enable all game objects for reference. 
    /// </summary>
    private void EnableGameObjects()
    {
        terrain.SetActive(true);
        audioSource.SetActive(true);
        frequenceCubes.SetActive(true);
    }

    /// <summary>
    /// Open the play menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }

    /// <summary>
    /// Close the play menu.
    /// </summary>
    public static void Hide()
    {
        Close();
    }

    /// <summary>
    /// Open the main menu.
    /// </summary>
    public void OpenMainMenu()
    {
        EnableGameObjects();

        MainMenu.Open();
        Hide();
    }

    /// <summary>
    /// Close the program.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}