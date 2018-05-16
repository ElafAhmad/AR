using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCinfo : MonoBehaviour {

	public Button btn1;
	public Button btn2;
	public Button btn3;
	public List<string> criminalName = new List<string> ();
	private List<string> tempName = new List<string> ();
	public Temp t;

	void Start () {
		t = FindObjectOfType<Temp> ();
		criminalName.Add (t.goalName);
		criminalName.Add (t.lureName [0]);
		criminalName.Add (t.lureName [1]);

		Text text1 = GetText (btn1);
		RandomText(text1);
		Text text2 = GetText (btn2);
		RandomText(text2);
		Text text3 = GetText (btn3);
		RandomText(text3);
	}

	Text GetText(Button btn){
		Text text = btn.GetComponentInChildren<Text> ();
		return text;
	}

	void RandomText(Text text){
		var index = Random.Range (0, criminalName.Count);
		text.text = criminalName [index];
		criminalName.RemoveAt (index);
	}

}
