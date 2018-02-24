using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour {
	private bool isPickup = false;
	public Camera cam;
	public GameObject pickUpPanel;
	public GameObject itemPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 1f)) {
			print ("HIT");
			Debug.Log (hit.transform.name);
			if (hit.transform.tag == "Item" && !isPickup ) {
				pickUpPanel.SetActive (true);
//			} else {
//				pickUpPanel.SetActive (false);
			}

//			Item target = hit.transform.GetComponent<Item> ();
//			target.Pickup ();
		} else {
			pickUpPanel.SetActive (false);
		}
	}

	public void IsPiackup(){
		isPickup = false;
	}
		
	public void PickedUp(){
		isPickup = true;
		pickUpPanel.SetActive (false);
		itemPanel.SetActive (true);
	}
}
