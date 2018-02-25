using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMusicButtonController : MonoBehaviour {

	public GameObject on;
	public GameObject off;
	public bool musicMute;
	Temp t;

	// Use this for initialization
	void Start () {
		t = FindObjectOfType<Temp> ();
		musicMute = t.musicMute;
	}
	
	// Update is called once per frame
	void Update () {
		t = FindObjectOfType<Temp> ();
		musicMute = t.musicMute;
		if (musicMute) {
			on.SetActive (musicMute);
			off.SetActive (!musicMute);
		}else{
			on.SetActive (musicMute);
			off.SetActive (!musicMute);
		}
	}
}
