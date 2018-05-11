using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData{

	public string status;
	public string sceneNameNow;
	public Scene sceneInfo;


	public GameData(string statusNew){
		status = statusNew;
		sceneNameNow = "No Name";
		sceneInfo = null;
	}

	public GameData(string statusNew, string sceneNameStr, Scene sceneInfoNew){
		status = statusNew;
		sceneNameNow = sceneNameStr;
		sceneInfo = sceneInfoNew;
	}
}
