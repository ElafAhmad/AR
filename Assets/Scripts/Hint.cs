using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour {

	public GameObject prefab;
	public GameObject cam;
	public Vector3[] cluePos;
	public Temp t;
	private bool cooldown = false;
	public Button button;
	private Image cdImage;
	public Sprite cdSprite;
	public Sprite cdResetSprite;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera");
		t = FindObjectOfType<Temp> ();
		cluePos = t.cluePos;
//		for (int i = 0; i<cluePos.Length;i++){
//			Vector3 tmp = cluePos [i];
//			tmp [1] = tmp [1] + 0.5f;
//			cluePos [i] = tmp;
//		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ShowHint(){
		if (cooldown == false) {
			button.interactable = false;
			cdImage = GetComponentInChildren<Image> ();
			cdImage.sprite = cdSprite;
			Invoke ("ResetCooldown", 3.0f);
			for (int i = 0; i < t.cluePos.Length; i++) {
				GameObject obj = Instantiate (prefab, cluePos [i], Quaternion.identity);
				Vector3 pos = new Vector3 (cam.transform.position.x, obj.transform.position.y, cam.transform.transform.position.z);
				obj.transform.LookAt (pos);
				Destroy (obj, 3f);
			}
			cooldown = true;
		}
	}

	void ResetCooldown(){
		cooldown = false;
		cdImage.sprite = cdResetSprite;
		button.interactable = true;
	}
}
