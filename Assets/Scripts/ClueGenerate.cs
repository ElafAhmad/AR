using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ClueGenerate : MonoBehaviour {
	
	private string sceneName;
	private string selectedSceneName;
	private string[] sceneNames = {"Robbery","Murder","Drug"};
	private GameObject hitParent;

	public Clue[] cluesItemPool;
	public Clue[] cluesCharPool;
	public Clue[] items;

//	public GameObject[] itemsGo;

//	private List<GameObject> itemsList = new List<GameObject> ();
	public Clue[] characters;

//	public GameObject[] charactersGo;

//	private List<GameObject> charactersList = new List<GameObject> ();

	private List<Clue> itemRealClueLists = new List<Clue> ();
	private List<Clue> characterRealClueLists = new List<Clue> ();
	public Clue[] selectedClues;
	private List<Clue> itemLureClueLists = new List<Clue> ();
	private List<Clue> charLureClueLists = new List<Clue> ();
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

	private List<Vector3> cluePosLists = new List<Vector3> ();
	public Vector3[] cluePos;
	private Temp t;

	public ScenceGenerator sG;
	public List<Scene> sceneList = new List<Scene> ();
	public Scene sceneInfo;

	public Text sceneIntro;
	public Text nameForScene;

	// Use this for initialization
	void Awake(){
		
	}

	void Start () {
		cM = FindObjectOfType<ClueManager> ();
		sG = FindObjectOfType<ScenceGenerator> ();
		t = FindObjectOfType<Temp> ();

		MurderItem = cM.MurderItemList.ToArray();
		MurderCharacter = cM.MurderCharacterList.ToArray();
		RobberyItem = cM.RobberyItemList.ToArray();
		RobberyCharacter = cM.RobberyCharacterList.ToArray();
		DrugItem = cM.DrugItemList.ToArray();
		DrugCharacter = cM.DrugCharacterList.ToArray();

		sceneName = SelectScene ();
		print ("Select : " + sceneName + " Scene.");
		SelectSceneFromSG ();
		ShowIntro ();
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
			Vector3 posTemp = new Vector3 (posX, 2f, posZ);
			cluePosLists.Add (posTemp);
			GameObject obj = Instantiate (selectedClues [i].model, posTemp, Quaternion.identity);
			obj.transform.localScale = 	new Vector3 (0.1f, 0.1f, 0.1f);
			if (selectedClues [i].type == "item") {
				var tmp = obj.GetComponent<Item> ();
				selectedClues[i].isReal = true;
				tmp.thisItem = selectedClues [i];
//			}
			} else if (selectedClues [i].type == "character") {
				var tmp = obj.GetComponent<Character> ();
				selectedClues [i].isReal = true;
				selectedClues [i].info = sceneInfo.fake;
				tmp.thisCharacter = selectedClues [i];
				if (i == 3) {
					t.goalName = selectedClues [i].name;
				}
			}
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
			Vector3 posTemp = new Vector3 (posX, 2f, posZ);
			cluePosLists.Add (posTemp);
			GameObject obj = Instantiate (lureClues [i].model, posTemp, Quaternion.identity);
			obj.transform.localScale = 	new Vector3 (0.1f, 0.1f, 0.1f);
			if (lureClues [i].type == "item") {
				var tmp = obj.GetComponent<Item> ();
				tmp.thisItem = lureClues [i];
//			}
			} else if (lureClues [i].type == "character") {
				var tmp = obj.GetComponent<Character> ();
				if (i == 2) {
					lureClues [i].info = sceneInfo.real1;
				}else if(i == 3) {
					lureClues [i].info = sceneInfo.real2;
				}
				tmp.thisCharacter = lureClues [i];
				if (i >= 2) {
					var temp = lureClues [i].name;
					t.lureName.Add (temp);
				}
			}
			obj.SetActive (true);
			obj.transform.parent = hitParent.transform;
		}
		cluePos = cluePosLists.ToArray();
		t.cluePos = cluePos;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SelectSceneFromSG(){
		if (sceneName == "Robbery") {
			sceneList = sG.robberySceneList;
			int i = Random.Range (0, sceneList.Count);
			sceneInfo = sceneList [i];
		} else if (sceneName == "Murder") {
			sceneList = sG.murderSceneList;
			int i = Random.Range (0, sceneList.Count);
			sceneInfo = sceneList [i];
		} else if (sceneName == "Drug") {
			sceneList = sG.drugSceneList;
			int i = Random.Range (0, sceneList.Count);
			sceneInfo = sceneList [i];
		}
	}

	void ShowIntro(){
		nameForScene.text = sceneInfo.name;
		sceneIntro.text = "\t" + sceneInfo.background;
	}

	string SelectScene(){
		selectedSceneName = sceneNames [Random.Range (0, 3)];
//		selectedSceneName = sceneNames [0];
		return selectedSceneName ;
	}

	void ConstructPool(){
		if (sceneName == "Robbery") {
			var tempItem1 = MurderItem;
			var tempItem2 = DrugItem;
			cluesItemPool = tempItem1.Concat(tempItem2).ToArray();
			var tempChar1 = MurderCharacter;
			var tempChar2 = DrugCharacter;
			cluesCharPool = tempChar1.Concat(tempChar2).ToArray();
		}
		else if (sceneName == "Murder") {
			var tempItem1 = RobberyItem;
			var tempItem2 = DrugItem;
			cluesItemPool = tempItem1.Concat(tempItem2).ToArray();
			var tempChar1 = RobberyCharacter;
			var tempChar2 = DrugCharacter;
			cluesCharPool = tempChar1.Concat(tempChar2).ToArray();
		}
		else if (sceneName == "Drug") {
			var tempItem1 = RobberyItem;
			var tempItem2 = MurderItem;
			cluesItemPool = tempItem1.Concat(tempItem2).ToArray();
			var tempChar1 = RobberyCharacter;
			var tempChar2 = MurderCharacter;
			cluesCharPool = tempChar1.Concat(tempChar2).ToArray();
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
//			SelectRealClue ();
			SelectRealClueV2 ();
		} else if (sceneName == "Murder") {
			items = MurderItem;
			characters = MurderCharacter;
//			SelectRealClue ();
			SelectRealClueV2 ();
		} else if (sceneName == "Drug") {
			items = DrugItem;
			characters = DrugCharacter;
//			SelectRealClue ();
			SelectRealClueV2 ();
		}

	}

	void SelectRealClue(){
		itemRealClueLists = items.ToList();
		characterRealClueLists = characters.ToList();
		print ("All Real Characters : "+characterRealClueLists.Count + " | All Real Items : "+itemRealClueLists.Count);
		selectedClues = new Clue[4];

		for (int i = 0; i < 3; i++) {
			var index = Random.Range (0, itemRealClueLists.Count);
			selectedClues [i] = itemRealClueLists [index];
//			selectedClues[i].model.SetActive(true);
			print ("Select : " + selectedClues[i].name + " as Real Clue.");
			itemRealClueLists.RemoveAt(index);
		}
		items = itemRealClueLists.ToArray ();
		print ("Real Items : " + items.Length + " Remaining.");

		for (int i = 0; i < 1; i++) {
			var index = Random.Range(0, characterRealClueLists.Count);
			selectedClues[i+3] = characterRealClueLists[index];
//			selectedClues[i+2].model.SetActive(true);
			print ("Select : " + selectedClues[i+3].name + " as Goal.");
			characterRealClueLists.RemoveAt(index);
		}
		characters = characterRealClueLists.ToArray ();
		print ("Real Characters : " + characters.Length + " Remaining.");
	}

	void SelectLureClue(){
		itemLureClueLists =  cluesItemPool.ToList ();
		charLureClueLists =  cluesCharPool.ToList ();
		print ("All Fake Characters : "+charLureClueLists.Count + " | All Fake Items : "+itemLureClueLists.Count);
		lureClues = new Clue[4];

		for (int i = 0; i < 2; i++) {
			var index = Random.Range(0, itemLureClueLists.Count);
			lureClues[i] = itemLureClueLists[index];
//			lureClues[i].model.SetActive(true);
			print ("Select : " + lureClues[i].name + " as Fake Clue.");
			itemLureClueLists.RemoveAt(index);
		}
		cluesItemPool = itemLureClueLists.ToArray ();
		print ("Fake Items : "+ cluesItemPool.Length + " Remaining.");

		for (int i = 0; i < 2; i++) {
			var index = Random.Range(0, charLureClueLists.Count);
			lureClues[i+2] = charLureClueLists[index];
			//			lureClues[i].model.SetActive(true);
			print ("Select : " + lureClues[i+2].name + " as Fake Character.");
			charLureClueLists.RemoveAt(index);
		}
		cluesCharPool = charLureClueLists.ToArray ();
		print ("Fake Characters : "+ cluesCharPool.Length + " Remaining.");
		print ("All Fake Items & Characters : " + lureClues.Length);
	}

	private List<Clue> selectedClueslist = new List<Clue> ();
	private List<Clue> tempItemClueslist = new List<Clue> ();

	void SelectRealClueV2(){
		itemRealClueLists = items.ToList ();
		characterRealClueLists = characters.ToList();
		print ("All Real Characters : "+characterRealClueLists.Count + " | All Real Items : "+itemRealClueLists.Count);

		foreach (Clue tempitem in itemRealClueLists) {
			if (tempitem.name == sceneInfo.itemName1) {
				tempitem.description = sceneInfo.itemDescription1;
				selectedClueslist.Add (tempitem);
				print ("Select : " + tempitem.name + " as Real Clue.");
			} else if (tempitem.name == sceneInfo.itemName2) {
				tempitem.description = sceneInfo.itemDescription2;
				selectedClueslist.Add (tempitem);
				print ("Select : " + tempitem.name + " as Real Clue.");
			} else if (tempitem.name == sceneInfo.itemName3) {
				tempitem.description = sceneInfo.itemDescription3;
				selectedClueslist.Add (tempitem);
				print ("Select : " + tempitem.name + " as Real Clue.");
			} else {
				tempItemClueslist.Add (tempitem);
			}
		}

//		print (tempItemClueslist.Count);
//		for (int i = 0; i < tempItemClueslist.Count; i++) {
//			print (tempItemClueslist [i].name);
//		}

		items = tempItemClueslist.ToArray ();
		print ("Real Items : " + items.Length + " Remaining.");

		for (int i = 0; i < 1; i++) {
			var index = Random.Range (0, characterRealClueLists.Count);
			selectedClueslist.Add(characterRealClueLists [index]);
			print ("Select : " + selectedClueslist [i + 3].name + " as Goal.");
			characterRealClueLists.RemoveAt (index);
		}
		characters = characterRealClueLists.ToArray ();
		selectedClues = selectedClueslist.ToArray ();
		print ("Real Characters : " + characters.Length + " Remaining.");
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
