using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenceGenerator : MonoBehaviour {

	public List<Scene> robberySceneList = new List<Scene> ();
	public List<Scene> murderSceneList = new List<Scene> ();
	public List<Scene> drugSceneList = new List<Scene> ();

	// Use this for initialization
	void Awake () {
		MakeSceneList ("Robbery", robberySceneList);
//		MakeSceneList ("Murder", murderSceneList);
//		MakeSceneList ("Drug", drugSceneList);
		
	}

	public void MakeSceneList(string tag, List<Scene> list){
		TextAsset asset = Resources.Load("CluesPrefabs/"+tag+"/scene") as TextAsset;
		//		Debug.Log(asset);
	
		//--------------------------------------------------------- for windows ----------------------------------------------------------------------------
		var textAsset = asset.text.Split (new string[] { "\r\n"},System.StringSplitOptions.None);
		//--------------------------------------------------------- for mac --------------------------------------------------------------------------------
		//var textAsset = asset.text.Split (new char[] {'\n'});

		for (int i = 0; i < textAsset.Length;){
			Scene preset = new Scene();
			preset.name = textAsset[i++];
			//			Debug.Log(preset.name+" : "+preset.name.Length);
			//			Debug.Log(preset.name[0]);
			//			Debug.Log(preset.name[1]);
			//			Debug.Log(preset.name[2]);
			preset.background = textAsset[i++];
			//			Debug.Log(preset.background);
			preset.real1 = textAsset[i++];
			//			Debug.Log(preset.real1);
			preset.real2 = textAsset[i++];
			//			Debug.Log(preset.real2);
			preset.fake = textAsset[i++];
			//			Debug.Log(preset.fake);
			list.Add (preset);
		}
	}
}
