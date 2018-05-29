using UnityEngine;
using UnityEngine.UI;

public class Audio : Menu<Audio>
{
    // Reference types.
    private GameObject terrain;
    private GameObject audioSource;
    private GameObject frequenceCubes;
    private AudioSource audioPeer;
    public Slider audioSlider;

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

        // Audiopeer.
        audioPeer = audioSource.GetComponent<AudioSource>();
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
    /// Set slider values in components.
    /// </summary>
    private void FixedUpdate()
    {
        // Audio volume.
        audioPeer.volume = audioSlider.value;
    }

    /// <summary>
    /// Open the audio menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }

    /// <summary>
    /// Close the audio menu.
    /// </summary>
    public static void Hide()
    {
        Close();
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
}