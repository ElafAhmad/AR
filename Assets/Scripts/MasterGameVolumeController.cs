using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MasterGameVolumeController : MonoBehaviour {
	public AudioSource clickSound;
	public AudioSource musicSound;
	public float volume;
	public bool musicMute;
	public bool clickMute;
	private int scenceIndex;
	Temp t;

	// Use this for initialization
	void Start () {
		t = FindObjectOfType<Temp> ();
		volume = t.musicVolume;
		musicMute = t.musicMute;
		clickMute = t.clickMute;
	}
	
	// Update is called once per frame
	void Update () {
		clickSound.mute = !clickMute;
		musicSound.mute = !musicMute;
		clickSound.volume = volume;
		musicSound.volume = volume;
	}

	public void PlayClickSound(){
		clickSound.Play ();
	}

	public void OnOffMusic(){
		musicSound.mute = !musicSound.mute;
	}

	public void OnOffEffect(){
		clickSound.mute = !clickSound.mute;
	}
		
}
