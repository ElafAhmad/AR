using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameData : MonoBehaviour {

	public string currentStatus = "Saved";
	public string currentSceneName;
	public Scene currentSceneInfo;

	// Use this for initialization
	void Start () {
//		currentSceneInfo = null;
//		currentSceneName = "No Name";
//		SaveFile();
//		LoadFile();
	}
	
	public void SaveFile()
	{
		string destination = Application.persistentDataPath + "/save.dat";
		FileStream file;

		if(File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		GameData data = new GameData (currentStatus, currentSceneName, currentSceneInfo);
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, data);
		file.Close();
		Debug.Log ("Save Completed");
	}

	public void LoadFile()
	{
		string destination = Application.persistentDataPath + "/save.dat";
		FileStream file;

		if(File.Exists(destination)) file = File.OpenRead(destination);
		else
		{
			Debug.LogError("File not found");
			return;
		}

		BinaryFormatter bf = new BinaryFormatter();
		GameData data = (GameData) bf.Deserialize(file);
		file.Close();

		currentStatus = data.status;
		currentSceneName = data.sceneNameNow;
		currentSceneInfo = data.sceneInfo;

		Debug.Log (destination);
		Debug.Log (currentStatus);
		Debug.Log (currentSceneName);
		Debug.Log (currentSceneInfo);
		Debug.Log ("Load Completed");
	}

	public void ResetFile()
	{
		currentStatus = "Reset";
		currentSceneName = "No Name";
		currentSceneInfo = null;
		SaveFile ();
		Debug.Log ("Reset Completed");
	}
}
