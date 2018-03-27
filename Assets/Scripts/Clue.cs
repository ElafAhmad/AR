using System.Collections;
using UnityEngine;
using System;

public class Clue {

	public string name;
	public string type;
	public string description;
	public string tag;
	public GameObject model;

	public Clue(){
		name = "No Name";
		type = "No Type";
		description = "No Description.";
		tag = "No Tag";
		model = null;
	}

	public Clue(string newName, string newType,string newTag){
		name = newName;
		type = newType;
		description = "No description.";
		tag = newTag;
		model = null;
	}

	public Clue(string newName, string newType, string newDescription,string newTag){
		name = newName;
		type = newType;
		description = newDescription;
		tag = newTag;
		model = null;
	}
		
}
