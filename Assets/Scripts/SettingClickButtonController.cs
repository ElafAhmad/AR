using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingClickButtonController : MonoBehaviour {

	public GameObject on;
	public GameObject off;
	public bool clickMute;
	Temp t;

	// Use this for initialization
	void Start () {
		t = FindObjectOfType<Temp> ();
		clickMute = t.clickMute;
	}
	
	// Update is called once per frame
	void Update () {
		t = FindObjectOfType<Temp> ();
		clickMute = t.clickMute;
		if (clickMute) {
			on.SetActive (clickMute);
			off.SetActive (!clickMute);
		}else{
			on.SetActive (clickMute);
			off.SetActive (!clickMute);
		}
	}
}
