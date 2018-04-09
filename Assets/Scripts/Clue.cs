using System.Collections;
using UnityEngine;
using System;

public class Clue {

	public string name;
	public string type;
	public string description;
	public string tag;
	public GameObject model;
	public bool isMinigame;
	public string info;
	public bool isReal;

	public Clue(){
		name = "No Name";
		type = "No Type";
		description = "No Description.";
		tag = "No Tag";
		model = null;
		isMinigame = false;
		info = "No Information.";
		isReal = false;
	}

	public Clue(string newName, string newType, string newTag){
		name = newName;
		type = newType;
		description = "No description.";
		tag = newTag;
		model = null;
		isMinigame = false;
		info = "No Information.";
		isReal = false;
	}

	public Clue(string newName, string newType, string newDescription, string newTag, string newInfo){
		name = newName;
		type = newType;
		description = newDescription;
		tag = newTag;
		model = null;
		isMinigame = false;
		info = newInfo;
		isReal = false;
	}
		
}
