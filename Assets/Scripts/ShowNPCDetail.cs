using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNPCDetail : MonoBehaviour {
	public Text npcName;
	public Text npcDes;
	public Character charactor;
	PickUpObject pUO;

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

}
