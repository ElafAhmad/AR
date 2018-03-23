using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {

	public GameObject prefab;
	public GameObject cam;
	public Vector3[] cluePos;
	public Temp t;

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
		for (int i = 0; i < t.cluePos.Length; i++) {
			GameObject obj = Instantiate (prefab, cluePos [i], Quaternion.identity);
			Vector3 pos = new Vector3 (cam.transform.position.x, obj.transform.position.y, cam.transform.transform.position.z);
			obj.transform.LookAt (pos);
			Destroy (obj, 3f);
		}
	}
}
