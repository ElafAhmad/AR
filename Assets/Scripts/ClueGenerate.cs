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

	public Clue[] characters;

	private List<Clue> itemRealClueLists = new List<Clue> ();
	private List<Clue> characterRealClueLists = new List<Clue> ();
	public Clue[] selectedClues;
	private List<Clue> itemLureClueLists = new List<Clue> ();
	private List<Clue> charLureClueLists = new List<Clue> ();
	public Clue[] lureClues;

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

	public GameObject cam;

	public SaveGameData sGD;

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

		sGD.LoadFile ();

		if ((sGD.currentSceneName != "No Name") && (sGD.currentSceneInfo != null)) {
			sceneName = sGD.currentSceneName;
			sceneInfo = sGD.currentSceneInfo;
		} else {
			sceneName = SelectScene ();
			print ("Select : " + sceneName + " Scene.");
			SelectSceneFromSG ();
			sGD.currentSceneName = sceneName;
			sGD.currentSceneInfo = sceneInfo;
			sGD.SaveFile ();
		}

		ShowIntro ();
		ConstructPool ();

		SelectItemNCharacter();
		hitParent = GameObject.Find ("HitCubeParent");
		SelectLureClue ();

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
			} else if (selectedClues [i].type == "character") {
				Vector3 pos = new Vector3 (cam.transform.position.x, obj.transform.position.y, cam.transform.position.z);
				obj.transform.localScale = 	new Vector3 (0.06f, 0.06f, 0.06f);
				obj.transform.LookAt (pos);
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
			} else if (lureClues [i].type == "character") {
				Vector3 pos = new Vector3 (cam.transform.position.x, obj.transform.position.y, cam.transform.position.z);
				obj.transform.localScale = 	new Vector3 (0.06f, 0.06f, 0.06f);
				obj.transform.LookAt (pos);
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
		if (sceneName == "Robbery") {
			items = RobberyItem;
			characters = RobberyCharacter;
			SelectRealClueV2 ();
		} else if (sceneName == "Murder") {
			items = MurderItem;
			characters = MurderCharacter;
			SelectRealClueV2 ();
		} else if (sceneName == "Drug") {
			items = DrugItem;
			characters = DrugCharacter;
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
			print ("Select : " + selectedClues[i].name + " as Real Clue.");
			itemRealClueLists.RemoveAt(index);
		}
		items = itemRealClueLists.ToArray ();
		print ("Real Items : " + items.Length + " Remaining.");

		for (int i = 0; i < 1; i++) {
			var index = Random.Range(0, characterRealClueLists.Count);
			selectedClues[i+3] = characterRealClueLists[index];
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
			print ("Select : " + lureClues[i].name + " as Fake Clue.");
			itemLureClueLists.RemoveAt(index);
		}
		cluesItemPool = itemLureClueLists.ToArray ();
		print ("Fake Items : "+ cluesItemPool.Length + " Remaining.");

		for (int i = 0; i < 2; i++) {
			var index = Random.Range(0, charLureClueLists.Count);
			lureClues[i+2] = charLureClueLists[index];
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
}
