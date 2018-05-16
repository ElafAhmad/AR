using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIsMiniGame : MonoBehaviour {

	public Button button;
	private Image isAbleImage;
	public Sprite isAbleSprite;
	public Sprite isUnableSprite;

	public void CheckMiniGame(){
		GameObject gO = GameObject.Find ("Main Camera");
		PickUpObject pUO = gO.GetComponent<PickUpObject> ();
		Item item = pUO.targer.GetComponent<Item> ();
		if (item.thisItem.isMinigame == false) {
			button.interactable = true;
			isAbleImage = GetComponentInChildren<Image> ();
			isAbleImage.sprite = isAbleSprite;
		} else {
			button.interactable = false;
			isAbleImage = GetComponentInChildren<Image> ();
			isAbleImage.sprite = isUnableSprite;
		}
	}



}
