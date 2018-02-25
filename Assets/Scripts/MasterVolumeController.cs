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
	
	// Update is called once per frame
	void Update () {
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
