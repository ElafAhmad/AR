using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour {

	public float musicVolume;
	public bool musicMute;
	public bool clickMute;
	MasterVolumeController mVC;

	// Use this for initialization
	void Start () {
		mVC = FindObjectOfType<MasterVolumeController> ();
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		musicVolume = mVC.volume;
		musicMute = mVC.musicMute;
		clickMute = mVC.clickMute;
	}
}
