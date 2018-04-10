using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNPCDetail : MonoBehaviour {
	public Text npcName;
	public Text npcDes;
	public Text npcInfo;
	public Character charactor;
	public GameObject button;
	PickUpObject pUO;
	public Jornal jornal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gO = GameObject.Find ("Main Camera");
		pUO = gO.GetComponent<PickUpObject> ();
		charactor = pUO.targer.GetComponent<Character> ();
		ShowName ();
		ShowDes ();
	}

	void ShowName(){
		npcName.text = charactor.thisCharacter.name;
	}
	void ShowDes(){
		npcDes.text = charactor.thisCharacter.description;
	}

	public void showInfo(){
		DeactiveDes ();
		npcInfo.gameObject.SetActive (true);
		npcInfo.text = charactor.thisCharacter.info;
		charactor.thisCharacter.isMinigame = true;
		jornal.ReceiveNewClue (charactor.thisCharacter);
	}

	public void DeactiveDes(){
		npcDes.gameObject.SetActive (false);
	}

	public void ActiveDes(){
		npcDes.gameObject.SetActive (true);
	}

	public void DeactiveInfo(){
		npcInfo.gameObject.SetActive (false);
	}

	public void CheckNPCInfo(){
		GameObject gO = GameObject.Find ("Main Camera");
		pUO = gO.GetComponent<PickUpObject> ();
		charactor = pUO.targer.GetComponent<Character> ();
		if (charactor.thisCharacter.isMinigame == false) {
			button.SetActive (true);
		} else {
			button.SetActive (false);
		}
	}


}
