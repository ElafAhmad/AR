using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemDetail : MonoBehaviour {
	public Text itemName;
	public Text itemDes;
	public Item item;
	PickUpObject pUO;

	void Update () {
		GameObject gO = GameObject.Find ("Main Camera");
		pUO = gO.GetComponent<PickUpObject> ();
		item = pUO.targer.GetComponent<Item> ();
		ShowName ();
		ShowDes ();
	}

	void ShowName(){
		itemName.text = item.thisItem.name;
	}
	void ShowDes(){
		itemDes.text = item.thisItem.description;
	}
}
