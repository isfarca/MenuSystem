using System;
using UnityEngine;
using UnityEngine.UI;

public class Settings : Menu<Settings>
{
    // Value types.
    private string[] konamiCode = new string[10] { "UpArrow", "UpArrow", "DownArrow", "DownArrow", "LeftArrow", "RightArrow", "LeftArrow", "RightArrow", "B", "A" };
    private string[] inputCode = new string[10];
    private int inputCounts = 0;
    private bool secretButtonEnabled = false;

    // Reference types.
    private GameObject terrain;
    private GameObject audioSource;
    private GameObject frequenceCubes;
    public Button secretButton;

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

        secretButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the keys for checking konami code.
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (inputCounts < 10)
                {
                    Debug.Log(keyCode.ToString());
                    inputCode[inputCounts] = keyCode.ToString();
                    inputCounts++;

                    // Reset the input counts.
                    if (keyCode.ToString() == "Backspace")
                    {
                        Debug.Log("Reset inputs!");
                        inputCounts = 0;
                    }
                }
                else
                {
                    Debug.Log("Reset inputs!");
                    inputCounts = 0;
                }
            }
        }

        // Check, whether the secret button is activated.
        if (inputCounts >= 10)
        {
            for (int i = 0; i < inputCounts; i++)
            {
                if (inputCode[i] != konamiCode[i])
                {
                    Debug.Log("Reset inputs!");
                    inputCounts = 0;
                    break;
                }
            }

            if (inputCounts != 0)
                secretButtonEnabled = true;
        }

        // Enable or Disable the secret button.
        secretButton.enabled = secretButtonEnabled;
        secretButton.gameObject.SetActive(secretButtonEnabled);
        // Debugging.
        if (secretButtonEnabled)
            Debug.Log("Secret button is enabled!");
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
    /// Open the settings menu.
    /// </summary>
    public static void Show()
    {
        Open();
    }

    /// <summary>
    /// Close the settings menu.
    /// </summary>
    public static void Hide()
    {
        Close();
    }

    /// <summary>
    /// Open the secret menu.
    /// </summary>
    public void OpenSecret()
    {
        EnableGameObjects();

        Secret.Open();
        Hide();
    }

    /// <summary>
    /// Open the graphics menu.
    /// </summary>
    public void OpenGraphics()
    {
        EnableGameObjects();

        Graphics.Open();
        Hide();
    }

    /// <summary>
    /// Open the audio menu.
    /// </summary>
    public void OpenAudio()
    {
        EnableGameObjects();

        Audio.Open();
        Hide();
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
}