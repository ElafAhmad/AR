using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scene {

	public string name;
	public string background;
	public string real1;
	public string real2;
	public string fake;
	public string itemName1;
	public string itemDescription1;
	public string itemName2;
	public string itemDescription2;
	public string itemName3;
	public string itemDescription3;

	public Scene(){
		name = "No Name";
		background = "No Backgroung";
		real1 = "No Information.";
		real2 = "No Information.";
		fake = "No Information.";
		itemName1 = null;
		itemDescription1 = null;
		itemName2 = null;
		itemDescription2 = null;
		itemName3 = null;
		itemDescription3 = null;
	}
}
