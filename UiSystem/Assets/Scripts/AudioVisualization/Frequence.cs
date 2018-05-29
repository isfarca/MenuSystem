using UnityEngine;

public class Frequence : MonoBehaviour
{
    // Value types.
    public int band = 0;
    public float startScale = 0.0f, scaleMultiplier = 0.0f;
	
	// Update is called once per frame
	void Update()
    {
        // Regulate scale value.
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.frequenceBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
	}
}