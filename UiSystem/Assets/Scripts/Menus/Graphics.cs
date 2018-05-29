using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graphics : Menu<Graphics>
{
    // Value types.
    private string option;
    private int currentResolutionIndex;

    // Reference types.
    private GameObject terrain;
    private GameObject audioSource;
    private GameObject frequenceCubes;
    private Resolution[] resolutions;
    private List<string> options = new List<string>();
    public Dropdown resolutionDropdown;

    // Use this for initialization
    void Start()
    {
        // Get the all resolutions from unity engine.
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        // Set the getting resolutions in a new list of resolutions.
        currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    /// <summary>
    /// Game object initialization.
    /// </summary>
    private void OnEnable()
    {
        // Terrain.
        terrain = GameObject.Find("Terrain");
        terrain.SetActive(true);

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
    /// Open the graphics menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }

    /// <summary>
    /// Close the graphics menu.
    /// </summary>
    public static void Hide()
    {
        Close();
    }

    /// <summary>
    /// Set quality by index.
    /// </summary>
    /// <param name="qualityIndex">Index of the quality setting.</param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /// <summary>
    /// Set the screen.
    /// </summary>
    /// <param name="isFullscreen">Is the screen full?</param>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    /// <summary>
    /// Set the resolution of the screen.
    /// </summary>
    /// <param name="resolutionIndex">The index of the resolution values.</param>
    public void SetResolution(int resolutionIndex)
    {
        // Declare variables.
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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