using UnityEngine;

public class MainMenu : Menu<MainMenu>
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
        audioSource.SetActive(true);

        // Frequences.
        frequenceCubes = GameObject.Find("Frequences");
        frequenceCubes.SetActive(true);
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
    /// Open the main menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }

    /// <summary>
    /// Close the main menu.
    /// </summary>
    public static void Hide()
    {
        Close();
    }

    /// <summary>
    /// Start the game.
    /// </summary>
    public void OpenPlay()
    {
        EnableGameObjects();

        Play.Open();
        Hide();
    }

    /// <summary>
    /// Open the settings menu.
    /// </summary>
    public void OpenSettings()
    {
        EnableGameObjects();

        Settings.Open();
        Hide();
    }

    /// <summary>
    /// Open the soundtrack menu.
    /// </summary>
    public void OpenSoundtrack()
    {
        EnableGameObjects();

        Soundtrack.Open();
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