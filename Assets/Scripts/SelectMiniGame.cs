using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMiniGame : MonoBehaviour {

	public MathBrain mB;
	public GameObject mBPanel;
	public PatternBrain pB;
	public GameObject pBPanel;

	public void SelectMini(){
		int index = Random.Range (0, 2);
		if (index == 1) {
			mBPanel.SetActive (true);
			mB.MiniGameStart ();
		} else {
			pBPanel.SetActive (true);
			pB.MiniGameStart ();
		}
	}

}
