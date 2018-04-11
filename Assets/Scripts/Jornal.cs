using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jornal : MonoBehaviour {

	public List<Info> lists = new List<Info> ();
	public Temp t;
	public GameObject prefab;
	public GameObject panel;
	RectTransform rectTransform;
	public GameObject scroll;
	public GameObject jornalButton;
	private Image notifyImage;
	public Sprite notifySprite;
	public Sprite normalSprite;

	// Use this for initialization
	void Start () {
		t = FindObjectOfType<Temp> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReceiveNewClue(Clue newClue){
		if (newClue.isReal && (newClue.type == "item")) {
			Info preset = new Info ();
			preset.name = newClue.name;
			preset.info = newClue.info + " " + t.goalName + ".";
			lists.Add (preset);
			var lastIndex = lists [lists.Count - 1];
			Debug.Log (lastIndex.name + " : " + lastIndex.info);
			int index = lists.Count - 1;
			SetNewHeight (index);
			ShowNewInfo (preset, index);
			notifyJornalButton ();

		} else if (!newClue.isReal && (newClue.type == "item")) {
			int i = Random.Range (0, 2);
			string lurename = t.lureName [i];
			Info preset = new Info ();
			preset.name = newClue.name;
			preset.info = newClue.info + " " + lurename + ".";
			lists.Add (preset);
			var lastIndex = lists [lists.Count - 1];
			Debug.Log (lastIndex.name + " : " + lastIndex.info);
			int index = lists.Count - 1;
			SetNewHeight (index);
			ShowNewInfo (preset, index);
			notifyJornalButton ();
		} else if (newClue.isReal && (newClue.type == "character")) {
			Info preset = new Info ();
			preset.name = newClue.name;
			preset.info = newClue.info;
			lists.Add (preset);
			var lastIndex = lists [lists.Count - 1];
			Debug.Log (lastIndex.name + " : " + lastIndex.info);
			int index = lists.Count - 1;
			SetNewHeight (index);
			ShowNewInfo (preset, index);
			notifyJornalButton ();

		} else if (!newClue.isReal && (newClue.type == "character")) {
			Info preset = new Info ();
			preset.name = newClue.name;
			preset.info = newClue.info;
			lists.Add (preset);
			var lastIndex = lists [lists.Count - 1];
			Debug.Log (lastIndex.name + " : " + lastIndex.info);
			int index = lists.Count - 1;
			SetNewHeight (index);
			ShowNewInfo (preset, index);
			notifyJornalButton ();
		}
	}

	void ShowNewInfo(Info newInfo, int i){
		int index = lists.Count - 1;
		GameObject obj = Instantiate (prefab,new Vector3 (0f,0f,0f),Quaternion.identity);
		obj.transform.SetParent (panel.transform);
		obj.transform.localScale = new Vector3(1f,1f,1f);
		rectTransform = obj.GetComponent<RectTransform> ();
//		rectTransform.position = new Vector3 (0,0f, panel.transform.position.z);
		rectTransform.localPosition = new Vector3 (0f ,0f, 0f);
		rectTransform.offsetMin = new Vector2(20, 0); // new Vector2(left, bottom);
		rectTransform.offsetMax = new Vector2(-20, 200); // new Vector2(-right, -top);
//		ratio = 1 : 0.1069701767147319f
//		rectTransform.position = new Vector3 (rectTransform.position.x,((23.533438877241f * index) * -1f) + 24.603140644388f, rectTransform.position.z);
		if (i < 3) {
			rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, (((220f * index) * -1f) + (-120f)) + 387, rectTransform.localPosition.z);
		} else if (i == 3) {
			rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, (((220f * index) * -1f) + (-120f)) + 450, rectTransform.localPosition.z);
		} else if (i == 4) {
			rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, (((220f * index) * -1f) + (-120f)) + 560, rectTransform.localPosition.z);
		} else if (i == 5) {
			rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, (((220f * index) * -1f) + (-120f)) + 670, rectTransform.localPosition.z);
		} else if (i == 6) {
			rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, (((220f * index) * -1f) + (-120f)) + 780, rectTransform.localPosition.z);
		} else if (i == 7) {
			rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, (((220f * index) * -1f) + (-120f)) + 890, rectTransform.localPosition.z);
		}
		Text name = obj.GetComponentInChildren<Text> ();
		name.text = newInfo.name;
		Transform child = obj.transform.Find ("Panel");
		Text info = child.GetComponentInChildren<Text> ();
		info.fontSize = 35;
		info.text = newInfo.info;
	}

	void SetNewHeight(int index){
		RectTransform rt = scroll.GetComponent <RectTransform> ();
		if (index == 3) {
			Vector3 curPos = rt.transform.localPosition;
			rt.sizeDelta = new Vector2 (1560,900);
			Vector3 distance = new Vector3 (0f, -6.739121133028f, 0f);
			rt.Translate (distance);
		}else if(index > 3){
			Vector3 curPos = rt.transform.localPosition;
			print (curPos);
			rt.sizeDelta += new Vector2 (0,220);
			Vector3 distance = new Vector3 (0f, -11.76671943862f, 0f);
			rt.Translate (distance);
		}
//		maxHeigth = 1780
//		posY -110 per newinfo
//		standard height = 774
//		-387
	}

	void notifyJornalButton(){
		notifyImage = jornalButton.GetComponent<Image> ();
		notifyImage.sprite = notifySprite;
	}

	public void resetJornalButton(){
		notifyImage = jornalButton.GetComponent<Image> ();
		notifyImage.sprite = normalSprite;
	}
}
