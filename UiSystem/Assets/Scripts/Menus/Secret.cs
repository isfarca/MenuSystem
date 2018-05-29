using UnityEngine;
using UnityEngine.UI;

public class Secret : Menu<Secret>
{
    // Reference types.
    private GameObject terrain;
    private GameObject audioSource;
    private GameObject frequenceCubes;
    private Light directionalLight;
    public Slider windzoneSlider;
    public Slider lightSlider;

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

        // Directional light.
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    /// <summary>
    /// Set slider values in components.
    /// </summary>
    private void FixedUpdate()
    {
        // Windzone.


        // Directional light.
        directionalLight.intensity = lightSlider.value;
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
    /// Open the secret menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }

    /// <summary>
    /// Close the secret menu.
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