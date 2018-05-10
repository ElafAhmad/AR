using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MasterVolumeController : MonoBehaviour {
	public Slider slider;
	public AudioSource clickSound;
	public AudioSource musicSound;
	public bool musicMute;
	public bool clickMute;
	private int scenceIndex;

	// Use this for initialization
	void Start () {
		musicMute = true;
		clickMute = true;
	}

	public void PlayClickSound(){
		clickSound.Play ();
	}

	public void OnOffMusic(){
		musicMute = musicSound.mute;
		musicSound.mute = !musicSound.mute;
		Save();
	}

	public void OnOffEffect(){
		clickMute = clickSound.mute;
		clickSound.mute = !clickSound.mute;
		Save();
	}

	public void Save() {
		PlayerPrefs.SetInt("MusicMute", musicMute ? 1 : 0); // Sets to 1 if true, 0 if false
		PlayerPrefs.SetInt("ClickMute", clickMute ? 1 : 0);
	}

	public void Load() {
		musicMute = PlayerPrefs.GetInt("MusicMute") == 1 ? true : false; // set to true if 1, false if 0
		clickMute = PlayerPrefs.GetInt("clickMute") == 1 ? true : false;
	}
		
}
