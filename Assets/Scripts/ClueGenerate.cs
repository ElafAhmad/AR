using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClueGenerate : MonoBehaviour {
	
	private string sceneName;
	private string selectedSceneName;
	private string[] sceneNames = {"Robbery","Murder","Drug"};
	private GameObject hitParent;

	public GameObject[] itemspool;

	public Clue[] Cluespool;
	public Clue[] items;

//	public GameObject[] itemsGo;

//	private List<GameObject> itemsList = new List<GameObject> ();
	public Clue[] characters;

//	public GameObject[] charactersGo;

//	private List<GameObject> charactersList = new List<GameObject> ();

	private List<Clue> itemClueLists = new List<Clue> ();
	private List<Clue> characterClueLists = new List<Clue> ();
	public Clue[] selectedClues;
	private List<Clue> lureClueLists = new List<Clue> ();
	public Clue[] lureClues;

//	private List<GameObject> itemObjectLists = new List<GameObject> ();
//	private List<GameObject> characterObjectLists = new List<GameObject> ();
//	public GameObject[] selectedObjects;
//	private List<GameObject> lureObjectLists = new List<GameObject> ();
//	public GameObject[] lureObjects;

	public ClueManager cM;
	public Clue[] MurderItem;
	public Clue[] MurderCharacter;
	public Clue[] RobberyItem;
	public Clue[] RobberyCharacter;
	public Clue[] DrugItem;
	public Clue[] DrugCharacter;

	// Use this for initialization
	void Awake(){
		
	}

	void Start () {
		cM = FindObjectOfType<ClueManager> ();

		MurderItem = cM.MurderItemList.ToArray();
		MurderCharacter = cM.MurderCharacterList.ToArray();
		RobberyItem = cM.RobberyItemList.ToArray();
		RobberyCharacter = cM.RobberyCharacterList.ToArray();
		DrugItem = cM.DrugItemList.ToArray();
		DrugCharacter = cM.DrugCharacterList.ToArray();

		sceneName = SelectScene ();
		print (sceneName);
		ConstructPool ();

		SelectItemNCharacter();
		hitParent = GameObject.Find ("HitCubeParent");
//		SelectLureObject ();
		SelectLureClue ();

//		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {

//		foreach (GameObject go in item) {
//			if (go.tag.Contains (sceneName)) {
//				selectedItem.Add (go);
//			}
//		}
//		print (selectedItem.Count);
//		vehicles = GameObject.FindGameObjectsWithTag ("Vehicle");
//		scenes = GetComponents<GameObject> ();

//		print (selectedClues.Length);
//		print ("0"+selectedClues[0].name);
//		Instantiate (selectedClues [0].model, new Vector3 (1f, 2f,1f),Quaternion.identity);
//		print ("1"+selectedClues[1].name);
//		Instantiate (selectedClues [1].model, new Vector3 (1f, 2f,1f),Quaternion.identity);
//		print ("2"+selectedClues[2].name);
//		Instantiate (selectedClues [2].model, new Vector3 (1f, 2f,1f),Quaternion.identity);
//		print ("3"+selectedClues[3].name);
//		Instantiate (selectedClues [3].model, new Vector3 (1f, 2f,1f),Quaternion.identity);

//		for (int i = 0; i < 4; i++) {
//			print (i+":"+selectedClues[i].name);
//		}

		for (int i=0; i<selectedClues.Length; i++){
			var posX = Random.Range (-2f, 1.5f);
			if (posX > -0.25f) {
				posX += 0.5f;
			}
			var posZ = Random.Range (-2f, 1.5f);
			if (posZ > -0.25f) {
				posZ += 0.5f;
			}
			GameObject obj = Instantiate (selectedClues [i].model, new Vector3 (posX, 2f, posZ),Quaternion.identity);
			obj.SetActive (true);
			obj.transform.parent = hitParent.transform;
		}

		for (int i=0; i<lureClues.Length; i++){
			var posX = Random.Range (-2f, 1.5f);
			if (posX > -0.25f) {
				posX += 0.5f;
			}
			var posZ = Random.Range (-2f, 1.5f);
			if (posZ > -0.25f) {
				posZ += 0.5f;
			}
			GameObject obj = Instantiate (lureClues [i].model, new Vector3 (posX, 2f, posZ),Quaternion.identity);
			obj.SetActive (true);
			obj.transform.parent = hitParent.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	string SelectScene(){
		selectedSceneName = sceneNames [Random.Range (0, 3)];
		return selectedSceneName ;
	}

	void ConstructPool(){
		if (sceneName == "Robbery") {
			var temp1 = MurderItem;
			var temp2 = DrugItem;
			Cluespool = temp1.Concat(temp2).ToArray();
		}
		else if (sceneName == "Murder") {
			var temp1 = RobberyItem;
			var temp2 = DrugItem;
			Cluespool = temp1.Concat(temp2).ToArray();
		}
		else if (sceneName == "Drug") {
			var temp1 = RobberyItem;
			var temp2 = MurderItem;
			Cluespool = temp1.Concat(temp2).ToArray();
		}

	}

	void SelectItemNCharacter(){
//		if (sceneName == "Robbery") {
//			for (int i = 0; i < RobberyItem.Length; i++) {
//				var temp = RobberyItem [i].model;
//				itemsList.Add(temp);
//			}
//			itemsGo = itemsList.ToArray();
//			for (int i = 0; i < RobberyCharacter.Length; i++) {
//				var temp = RobberyCharacter [i].model;
//				charactersList.Add(temp);
//			}
//			charactersGo = charactersList.ToArray();
//			SelectTrueObject ();
//
//		} else if (sceneName == "Murder") {
//			for (int i = 0; i < MurderItem.Length; i++) {
//				var temp = MurderItem [i].model;
//				itemsList.Add(temp);
//			}
//			itemsGo = itemsList.ToArray();
//			for (int i = 0; i < MurderCharacter.Length; i++) {
//				var temp = MurderCharacter [i].model;
//				charactersList.Add(temp);
//			}
//			charactersGo = charactersList.ToArray();
//			SelectTrueObject ();
//
//		} else if (sceneName == "Drug") {
//			for (int i = 0; i < DrugItem.Length; i++) {
//				var temp = DrugItem [i].model;
//				itemsList.Add(temp);
//			}
//			itemsGo = itemsList.ToArray();
//			for (int i = 0; i < DrugCharacter.Length; i++) {
//				var temp = DrugCharacter [i].model;
//				charactersList.Add(temp);
//			}
//			charactersGo = charactersList.ToArray();
//			SelectTrueObject ();
//		}

		if (sceneName == "Robbery") {
			items = RobberyItem;
			characters = RobberyCharacter;
			SelectRealClue ();
		} else if (sceneName == "Murder") {
			items = MurderItem;
			characters = MurderCharacter;
			SelectRealClue ();
		} else if (sceneName == "Drug") {
			items = DrugItem;
			characters = DrugCharacter;
			SelectRealClue ();
		}

	}

	void SelectRealClue(){
		itemClueLists = items.ToList();
		print ("items :"+itemClueLists.Count);
		characterClueLists = characters.ToList();
		print ("characters :"+characterClueLists.Count);
		selectedClues = new Clue[4];

		for (int i = 0; i < 3; i++) {
			var index = Random.Range (0, itemClueLists.Count);
			selectedClues [i] = itemClueLists [index];
//			selectedClues[i].model.SetActive(true);
			print (selectedClues[i].name);
			itemClueLists.RemoveAt(index);
		}
		items = itemClueLists.ToArray ();
		print ("items :" + items.Length);

		for (int i = 0; i < 1; i++) {
			var index = Random.Range(0, characterClueLists.Count);
			selectedClues[i+3] = characterClueLists[index];
//			selectedClues[i+2].model.SetActive(true);
			print (selectedClues[i+3].name);
			characterClueLists.RemoveAt(index);
		}
		characters = characterClueLists.ToArray ();
		print ("characters :" + characters.Length);
	}

	void SelectLureClue(){
		lureClueLists =  Cluespool.ToList ();
		print ("Cluespool :"+lureClueLists.Count);
		lureClues = new Clue[2];

		for (int i = 0; i < 2; i++) {
			var index = Random.Range(0, lureClueLists.Count);
			lureClues[i] = lureClueLists[index];
//			lureClues[i].model.SetActive(true);
			print (lureClues[i].name);
			lureClueLists.RemoveAt(index);
		}
		Cluespool = lureClueLists.ToArray ();
		print ("Cluespool :"+Cluespool.Length);
		print ("lureClues :" + lureClues.Length);
	}

//-----------------------------------------------------------------------------------------------------------------------------------------------------------

//	void SelectTrueObject(){
//		itemObjectLists =  itemsGo.ToList ();
//		characterObjectLists =  charactersGo.ToList ();
//		selectedObjects = new GameObject[3];
//
//		for (int i = 0; i < 2; i++) {
//			var index = Random.Range(0, itemObjectLists.Count);
//			selectedObjects[i] = itemObjectLists[index];
//			selectedObjects[i].SetActive(true);
//			itemObjectLists.RemoveAt(index);
//		}
//		itemsGo = itemObjectLists.ToArray ();
//
//		for (int i = 0; i < 1; i++) {
//			var index = Random.Range(0, characterObjectLists.Count);
//			selectedObjects[i+2] = characterObjectLists[index];
//			selectedObjects[i+2].SetActive(true);
//			characterObjectLists.RemoveAt(index);
//		}
//		charactersGo = characterObjectLists.ToArray ();
//	}
//
//	void SelectLureObject(){
//		lureObjectLists =  itemspool.ToList ();
//		lureObjects = new GameObject[2];
//
//		for (int i = 0; i < 2; i++) {
//			var index = Random.Range(0, lureObjectLists.Count);
//			lureObjects[i] = lureObjectLists[index];
//			lureObjects[i].SetActive(true);
//			lureObjectLists.RemoveAt(index);
//		}
//		itemspool = lureObjectLists.ToArray ();
//	}
}
