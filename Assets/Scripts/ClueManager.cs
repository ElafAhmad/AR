using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ClueManager : MonoBehaviour {

	public List<Clue> MurderItemList = new List<Clue> ();
	public List<Clue> MurderCharacterList = new List<Clue> ();
	public List<Clue> RobberyItemList = new List<Clue> ();
	public List<Clue> RobberyCharacterList = new List<Clue> ();
	public List<Clue> DrugItemList = new List<Clue> ();
	public List<Clue> DrugCharacterList = new List<Clue> ();

	void Awake() {

		MakeList ("Item","Robbery", RobberyItemList);
		MakeList ("Item","Murder", MurderItemList);
		MakeList ("Item","Drug", DrugItemList);
		MakeList ("Character","Robbery", RobberyCharacterList);
		MakeList ("Character","Murder", MurderCharacterList);
		MakeList ("Character","Drug", DrugCharacterList);

	}

	public void MakeList(string type, string tag, List<Clue> list){
		TextAsset asset = Resources.Load("CluesPrefabs/"+tag+"/"+type+"/detail") as TextAsset;

//--------------------------------------------------------- for windows ----------------------------------------------------------------------------
		var textAsset = asset.text.Split (new string[] { "\r\n"},System.StringSplitOptions.None);
//--------------------------------------------------------- for mac --------------------------------------------------------------------------------
//		var textAsset = asset.text.Split (new char[] {'\n'});

		for (int i = 0; i < textAsset.Length;){
			Clue preset = new Clue();
			preset.tag = tag;
			preset.name = textAsset[i++];
//			Debug.Log(preset.name+" : "+preset.name.Length);
//			Debug.Log(preset.name[0]);
//			Debug.Log(preset.name[1]);
//			Debug.Log(preset.name[2]);
			preset.type = textAsset[i++];
//			Debug.Log(preset.type);
			preset.description = textAsset[i++];
//			Debug.Log(preset.description);
			preset.model = Resources.Load<GameObject> ("CluesPrefabs/"+tag+"/"+type+"/"+preset.name);
//			Debug.Log(preset.model);
			preset.info = textAsset[i++];
//			Debug.Log(preset.info+" : "+preset.info.Length);
			list.Add (preset);
		}
	}
}
