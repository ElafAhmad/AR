using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MasterGameVolumeController : MonoBehaviour {
	public AudioSource clickSound;
	public AudioSource musicSound;
	public bool musicMute;
	public bool clickMute;
	private int scenceIndex;
	Temp t;
	public AudioSource correctSound;
	public AudioSource incorrectSound;

	void Start () {
		t = FindObjectOfType<Temp> ();
		musicMute = t.musicMute;
		clickMute = t.clickMute;
		clickSound.mute = !clickMute;
		musicSound.mute = !musicMute;
		correctSound.mute = !clickMute;
		incorrectSound.mute = !clickMute;
	}

	void Update () {
		t = FindObjectOfType<Temp> ();
		clickSound.mute = !clickMute;
		musicSound.mute = !musicMute;
		correctSound.mute = !clickMute;
		incorrectSound.mute = !clickMute;
	}

	public void PlayClickSound(){
		clickSound.Play ();
	}

	public void PlayCorrectSound(){
		correctSound.Play ();
	}

	public void PlayIncorrectSound(){
		incorrectSound.Play ();
	}

	public void OnOffMusic(){
		musicMute = musicSound.mute;
		musicSound.mute = !musicSound.mute;
		Save();
	}

	public void OnOffEffect(){
		clickMute = clickSound.mute;
		clickSound.mute = !clickSound.mute;
		correctSound.mute = !clickSound.mute;
		incorrectSound.mute = !clickSound.mute;
		Save();
	}

	public void Save()
	{
		PlayerPrefs.SetInt("MusicGameMute", musicMute ? 1 : 0); // Sets to 1 if true, 0 if false
		PlayerPrefs.SetInt("ClickGameMute", clickMute ? 1 : 0);
	}

	public void Load() {
		musicMute = PlayerPrefs.GetInt("MusicGameMute") == 1 ? true : false; // set to true if 1, false if 0
		clickMute = PlayerPrefs.GetInt("ClickGameMute") == 1 ? true : false;
	}
		
}
