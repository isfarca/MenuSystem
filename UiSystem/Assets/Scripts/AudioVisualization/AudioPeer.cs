using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    // Value types.
    private int count;
    private int sampleCount;
    private float average;
    public static float[] samples = new float[512];
    public static float[] frequenceBand = new float[8];

    // Reference types.
    private AudioSource audioSource;

    /// <summary>
    /// Initialize the variables.
    /// </summary>
    private void Awake()
    {
        // Init standart values for variables.
        sampleCount = 0;
        average = 0.0f;

        // Get the audio source component from the game object.
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update()
    {
        // Get spectrum audio source.
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

        // Make frequency bands.
        /*
         * 22050 / 512 = 43Hz/sample.
         * 
         * 20 - 60Hz.
         * 60 - 250Hz.
         * 250 - 500Hz.
         * 500 - 2000Hz.
         * 2000 - 4000Hz.
         * 4000 - 6000Hz.
         * 6000 - 20000Hz.
         * 20000 - 22050Hz.
         * 
         * 0: 2 = 86Hz.
         * 1: 4 = 172Hz.
         * 2: 8 = 344Hz.
         * 3: 16 = 688Hz.
         * 4: 42 = 1376Hz.
         * 5: 84 = 2752Hz.
         * 6: 168 = 5504Hz.
         * 7: 336 = 11008Hz.
         * 
         * -> 510.
         */

        // Reset the integer variable.
        count = 0;

        // Set the frequence bands.
        for (int i = 0; i < frequenceBand.Length; i++)
        {
            sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
                sampleCount += 2;

            for (int j = 0; j < sampleCount; j++)
            {
                average += (samples[count] * (count + 1));

                count++;
            }

            average /= count;

            frequenceBand[i] = average * 10.0f;
        }
	}
}