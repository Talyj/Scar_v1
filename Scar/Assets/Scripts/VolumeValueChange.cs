﻿using UnityEngine;

public class VolumeValueChange : MonoBehaviour {

    private AudioSource audioSrc;
    private float musicVolume = 1f;

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