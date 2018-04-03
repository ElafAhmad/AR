using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCooldown : MonoBehaviour {

	private bool cooldown = false;

	void OnButtonClick(){
		if (cooldown == false) {
			Invoke ("ResetCooldown", 5.0f);
			cooldown = true;
		}
	}
	void ResetCooldown(){
		cooldown = false;
	}
}
