using UnityEngine;

public class VolumeValueChange : MonoBehaviour {

    private AudioSource audioSrc;
    private float musicVolume = 0.5f;

	void Start () {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = musicVolume;
	}
	
	void Update () {
        audioSrc.volume = musicVolume;
	}

    public void SetVolume(float vol) {
        musicVolume = vol;
    }
}