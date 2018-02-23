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
	public GameObject[] items;
	public GameObject[] characters;

	private List<GameObject> itemObjectLists = new List<GameObject>();
	private List<GameObject> charactersObjectLists = new List<GameObject>();
	public GameObject[] selectedObjects;
	private List<GameObject> lureObjectLists = new List<GameObject>();
	public GameObject[] lureObjects;

	// Use this for initialization
	void Awake(){
		sceneName = SelectScene ();
		print (sceneName);
		ConstructPool ();

		SelectItemNCharacter();
		hitParent = GameObject.Find ("HitCubeParent");
		SelectLureObject ();
	}

	void Start () {

//		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {

//		foreach (GameObject go in item) {
//			if (go.tag.Contains (sceneName)) {
//				selectedItem.Add (go);
//			}
//		}
//		print (selectedItem.Count);
//		vehicles = GameObject.FindGameObjectsWithTag ("Vehicle");
//		scenes = GetComponents<GameObject> ();


		for (int i=0; i<selectedObjects.Length; i++){
			GameObject obj = Instantiate (selectedObjects [i], new Vector3 (Random.Range (-2f, 2f), 1f,Random.Range (-2f, 2f)),Quaternion.identity);
			obj.SetActive (true);
			obj.transform.parent = hitParent.transform;
		}

		for (int i=0; i<lureObjects.Length; i++){
			GameObject obj = Instantiate (lureObjects [i], new Vector3 (Random.Range (-2f, 2f), 1f,Random.Range (-2f, 2f)),Quaternion.identity);
			obj.SetActive (true);
			obj.transform.parent = hitParent.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	string SelectScene(){
		selectedSceneName = sceneNames [Random.Range (0, 3)];
		return selectedSceneName;
	}

	void ConstructPool(){
		if (sceneName == "Robbery") {
			var temp1 = Resources.LoadAll<GameObject>("CluesPrefabs/Murder/Item");
			var temp2 = Resources.LoadAll<GameObject>("CluesPrefabs/Drug/Item");
			itemspool = temp1.Concat(temp2).ToArray();
		}
		else if (sceneName == "Murder") {
			var temp1 = Resources.LoadAll<GameObject>("CluesPrefabs/Robbery/Item");
			var temp2 = Resources.LoadAll<GameObject>("CluesPrefabs/Drug/Item");
			itemspool = temp1.Concat(temp2).ToArray();
		}
		else if (sceneName == "Drug") {
			var temp1 = Resources.LoadAll<GameObject>("CluesPrefabs/Robbery/Item");
			var temp2 = Resources.LoadAll<GameObject>("CluesPrefabs/Murder/Item");
			itemspool = temp1.Concat(temp2).ToArray();
		}

	}

	void SelectItemNCharacter(){
		if (sceneName == "Robbery") {
			items = Resources.LoadAll<GameObject>("CluesPrefabs/Robbery/Item");
			characters = Resources.LoadAll<GameObject>("CluesPrefabs/Robbery/character");
			SelectTrueObject();
		}
		else if (sceneName == "Murder") {
			items = Resources.LoadAll<GameObject>("CluesPrefabs/Murder/Item");
			characters = Resources.LoadAll<GameObject>("CluesPrefabs/Murder/character");
			SelectTrueObject();
		}
		else if (sceneName == "Drug") {
			items = Resources.LoadAll<GameObject>("CluesPrefabs/Drug/Item");
			characters = Resources.LoadAll<GameObject>("CluesPrefabs/Drug/character");
			SelectTrueObject();
		}
	}

	void SelectTrueObject(){
		itemObjectLists =  items.ToList ();
		charactersObjectLists =  characters.ToList ();
		selectedObjects = new GameObject[3];

		for (int i = 0; i < 2; i++) {
			var index = Random.Range(0, itemObjectLists.Count);
			selectedObjects[i] = itemObjectLists[index];
			selectedObjects[i].SetActive(true);
			itemObjectLists.RemoveAt(index);
		}
		items = itemObjectLists.ToArray ();

		for (int i = 0; i < 1; i++) {
			var index = Random.Range(0, charactersObjectLists.Count);
			selectedObjects[i+2] = charactersObjectLists[index];
			selectedObjects[i+2].SetActive(true);
			charactersObjectLists.RemoveAt(index);
		}
		characters = charactersObjectLists.ToArray ();
	}

	void SelectLureObject(){
		lureObjectLists =  itemspool.ToList ();
		lureObjects = new GameObject[2];

		for (int i = 0; i < 2; i++) {
			var index = Random.Range(0, lureObjectLists.Count);
			lureObjects[i] = lureObjectLists[index];
			lureObjects[i].SetActive(true);
			lureObjectLists.RemoveAt(index);
		}
		itemspool = lureObjectLists.ToArray ();
	}
}
