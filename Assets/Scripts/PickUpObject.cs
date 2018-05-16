using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour {
	private bool isPickup = false;
	private bool isTalk = false;
	public Camera cam;
	public GameObject pickUpPanel;
	public GameObject itemPanel;
	public GameObject jornalButtonPanel;
	public GameObject hintButtonPanel;
	public GameObject settingButtonPanel;
	public GameObject settingPanel;
	public GameObject jornalPanel;
	public GameObject itemPreviewPanel;
	public GameObject targer;

	public GameObject talkPanel;
	public GameObject npcPanel;

	void Start () {
	}

	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 0.50f)) {
			print ("HIT");
			Debug.Log (hit.transform.name);
			if (hit.transform.tag == "Item" && !isPickup) {
				pickUpPanel.SetActive (true);
				targer = hit.transform.gameObject;
			} else if (hit.transform.tag == "Character" && !isTalk) {
				talkPanel.SetActive (true);
				targer = hit.transform.gameObject;
			}
		} else {
			pickUpPanel.SetActive (false);
			talkPanel.SetActive (false);
		}
	}

	public void Talk(){
		isTalk = true;
		isPickup = true;
		talkPanel.SetActive (false);
		npcPanel.SetActive (true);
		jornalButtonPanel.SetActive (false);
		hintButtonPanel.SetActive (false);
	}

	public void CloseTalk(){
		isTalk = false;
		isPickup = false;
		talkPanel.SetActive (false);
		jornalButtonPanel.SetActive (true);
		hintButtonPanel.SetActive (true);
	}

	public void PickedUp(){
		isPickup = true;
		isTalk = true;
		pickUpPanel.SetActive (false);
		itemPanel.SetActive (true);
		jornalButtonPanel.SetActive (false);
		hintButtonPanel.SetActive (false);
	}

	public void ClosePickup(){
		isPickup = false;
		isTalk = false;
		itemPanel.SetActive (false);
		jornalButtonPanel.SetActive (true);
		hintButtonPanel.SetActive (true);
	}

	public void Jornal(){
		jornalPanel.SetActive (true);
		jornalButtonPanel.SetActive (false);
		hintButtonPanel.SetActive (false);
	}

	public void CloseJornal(){
		jornalPanel.SetActive (false);
		jornalButtonPanel.SetActive (true);
		hintButtonPanel.SetActive (true);
	}

	public void Setting(){
		settingButtonPanel.SetActive (false);
		settingPanel.SetActive (true);
		itemPanel.SetActive (false);
		jornalPanel.SetActive (false);
		jornalButtonPanel.SetActive (false);
		hintButtonPanel.SetActive (false);
		itemPreviewPanel.SetActive (false);
		npcPanel.SetActive (false);
	}

	public void CloseSetting(){
		settingButtonPanel.SetActive (true);
		settingPanel.SetActive (false);
		CloseJornal ();
		ClosePickup ();
		CloseTalk ();
	}
}
