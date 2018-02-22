using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClueGenerate : MonoBehaviour {
	
	private string sceneName;
	private string selectedSceneName;
	private string[] sceneNames = {"Robbery","Murder","Drug"};
	private GameObject hitParent;
	public GameObject[] items;
//	public GameObject[] characters;
	public GameObject[] reservedObjects;
	public GameObject[] selectedObjects;
	private List<GameObject> reservedObjectLists = new List<GameObject>();


	// Use this for initialization
	void Awake(){
		sceneName = SelectScene ();
		print (sceneName);

		SelectItemNCharacter();
		hitParent = GameObject.Find ("HitCubeParent");
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

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	string SelectScene(){
		
		selectedSceneName = sceneNames [Random.Range (0, 3)];
		return selectedSceneName;

	}

	void SelectItemNCharacter(){
		
		if (sceneName == "Robbery") {

			items = Resources.LoadAll<GameObject>("CluesPrefabs/Robbery");

//			items = GameObject.FindGameObjectsWithTag ("iRobbery");
//			characters = GameObject.FindGameObjectsWithTag ("cRobbery");
			ReservedObject ();
			SelectedObject ();

		}
		else if (sceneName == "Murder") {

			items = Resources.LoadAll<GameObject>("CluesPrefabs/Murder");

//			items = GameObject.FindGameObjectsWithTag ("iMurder");
//			characters = GameObject.FindGameObjectsWithTag ("cMurder");
			ReservedObject ();
			SelectedObject ();

		}
		else if (sceneName == "Drug") {

			items = Resources.LoadAll<GameObject>("CluesPrefabs/Drug");

//			items = GameObject.FindGameObjectsWithTag ("iDrug");
//			characters = GameObject.FindGameObjectsWithTag ("cDrug");
			ReservedObject ();
			SelectedObject ();

		}

	}

	void ReservedObject(){
		
//		reservedObjects = new GameObject[items.Length + characters.Length];
//		items.CopyTo (reservedObjects, 0);
//		characters.CopyTo (reservedObjects, items.Length);
		reservedObjects = items;
		reservedObjects.Reverse ();
	}

	void SelectedObject(){
		
		reservedObjectLists = reservedObjects.ToList ();
		selectedObjects = new GameObject[3];
		for (int i = 0; i < selectedObjects.Length; i++) {
			var index = Random.Range(0, reservedObjectLists.Count);
			selectedObjects[i] = reservedObjectLists[index];
			selectedObjects[i].SetActive(true);
			reservedObjectLists.RemoveAt(index);
		}
		reservedObjects = reservedObjectLists.ToArray ();

	}

}
