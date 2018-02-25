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

	// Use this for initialization
	void Start () {
		t = FindObjectOfType<Temp> ();
		musicMute = t.musicMute;
		clickMute = t.clickMute;
		clickSound.mute = !clickMute;
		musicSound.mute = !musicMute;
	}
	
	// Update is called once per frame
	void Update () {
		t = FindObjectOfType<Temp> ();
		clickSound.mute = !clickMute;
		musicSound.mute = !musicMute;
	}

	public void PlayClickSound(){
		clickSound.Play ();
	}

	public void OnOffMusic(){
		musicMute = musicSound.mute;
		musicSound.mute = !musicSound.mute;
	}

	public void OnOffEffect(){
		clickMute = clickSound.mute;
		clickSound.mute = !clickSound.mute;
	}
		
}
