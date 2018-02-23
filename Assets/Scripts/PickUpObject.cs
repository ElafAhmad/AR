using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {
	public Camera cam;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward,out hit,1f)) {
			print ("HIT");
			Debug.Log (hit.transform.name);
			Item target = hit.transform.GetComponent<Item> ();
			target.Pickup ();
		}
	}
}
