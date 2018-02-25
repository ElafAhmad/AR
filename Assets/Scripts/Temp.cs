using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour {

	public bool musicMute;
	public bool clickMute;
	public MasterVolumeController mVC;
	public MasterGameVolumeController mGVC;

	// Use this for initialization
	void Start () {
		mVC = FindObjectOfType<MasterVolumeController> ();
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		mGVC = FindObjectOfType<MasterGameVolumeController> ();
		musicMute = mVC.musicMute;
		clickMute = mVC.clickMute;
		musicMute = mGVC.musicMute;
		clickMute = mGVC.clickMute;
	}
}
