using UnityEngine;
using UnityEngine.UI;

public class Soundtrack : Menu<Soundtrack>
{
    // Value types.
    private int currentMusic = 0;
    private bool pause = false;

    // Reference types.
    private GameObject terrain;
    private GameObject audioSource;
    private GameObject frequenceCubes;
    private AudioSource beAudioSource;
    public AudioClip[] soundtracks;
    public Text musicText;
    public Slider musicSlider;

    // Use this for initialization
    void Start()
    {
        StartAudio();
    }

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
        frequenceCubes.SetActive(true);

        // Be audio source.
        beAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the music slider value, when the music not pause.
        if (!pause)
        {
            musicSlider.value += Time.deltaTime;

            // Basic music slider handling.
            if (musicSlider.value >= beAudioSource.clip.length)
            {
                currentMusic++;

                if (currentMusic >= soundtracks.Length)
                    currentMusic = 0;

                StartAudio();
            }
        }
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
    /// Start playing audio
    /// </summary>
    /// <param name="changeMusic">Change the soundtrack from the array by index.</param>
    public void StartAudio(int changeMusic = 0)
    {
        // Change the music.
        currentMusic += changeMusic;

        if (currentMusic >= soundtracks.Length)
            currentMusic = 0;
        else if (currentMusic < 0)
            currentMusic = soundtracks.Length - 1;
        
        // Continue play audio.
        if (beAudioSource.isPlaying && changeMusic == 0)
            return;

        // Set stop playing audio.
        if (pause)
            pause = false;

        // Set components with informations of the current playing music.
        beAudioSource.clip = soundtracks[currentMusic];
        musicText.text = beAudioSource.clip.name;
        musicSlider.maxValue = beAudioSource.clip.length;
        musicSlider.value = 0;

        // Play the audio.
        beAudioSource.Play();
    }

    public void PauseAudio()
    {
        beAudioSource.Pause();
        pause = true;
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