using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour {
	private bool isPickup = false;
	private bool isJornal = false;
	public Camera cam;
	public GameObject pickUpPanel;
	public GameObject itemPanel;
	public GameObject jornalButtonPanel;
	public GameObject jornalPanel;
	public GameObject targer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 0.5f)) {
			print ("HIT");
			Debug.Log (hit.transform.name);
			if (hit.transform.tag == "Item" && !isPickup ) {
				pickUpPanel.SetActive (true);
				TestIsJornal ();
				targer = hit.transform.gameObject;
//			} else {
//				pickUpPanel.SetActive (false);
			}
		}
		else if(isJornal){
			jornalButtonPanel.SetActive (false);
		} else {
			pickUpPanel.SetActive (false);
			jornalButtonPanel.SetActive (true);
		}
	}

	public void IsPiackup(){
		isPickup = false;
	}
		
	public void PickedUp(){
		isPickup = true;
		pickUpPanel.SetActive (false);
		itemPanel.SetActive (true);
		jornalButtonPanel.SetActive (false);
	}

	public void Jornal(){
		isJornal = true;
		jornalPanel.SetActive (true);
	}

	public void IsJornal(){
		isJornal = false;
	}

	public void TestIsJornal(){
		if (isJornal) {
			jornalButtonPanel.SetActive (false);
		} else if (!isJornal) {
			jornalButtonPanel.SetActive (true);
		}
	}
}
