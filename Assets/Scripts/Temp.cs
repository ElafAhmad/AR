using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temp : MonoBehaviour {

	public bool musicMute;
	public bool clickMute;
	public MasterVolumeController mVC;
	public MasterGameVolumeController mGVC;
	public Vector3[] cluePos;
	public string goalName;
	public List<string> lureName = new List<string> ();

	void Start () {
		DontDestroyOnLoad (this);
	}

	void Update () {
		int index = SceneManager.GetActiveScene().buildIndex;
		CheckSceneIndex (index);
	}

	public void CheckSceneIndex(int index){
		if (index == 0) {
			mVC = FindObjectOfType<MasterVolumeController> ();
			musicMute = mVC.musicMute;
			clickMute = mVC.clickMute;
		} 
		else if (index == 1) {
			mGVC = FindObjectOfType<MasterGameVolumeController> ();
			musicMute = mGVC.musicMute;
			clickMute = mGVC.clickMute;
		}

	}
}
