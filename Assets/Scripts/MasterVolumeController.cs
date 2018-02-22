using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeController : MonoBehaviour {
	public Slider slider;
	public AudioSource clickSound;
	public AudioSource musicSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		clickSound.volume = slider.value;
		musicSound.volume = slider.value;
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
