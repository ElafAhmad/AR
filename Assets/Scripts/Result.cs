using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {

	public GameObject resultPanel;
	public Jornal j;
	public Temp t;
//	public List<string> nameList = new List<string> ();
	public Text resultName;

	public GameObject imagePanel;
	private Image resultImage;
	public Sprite trueSprite;
	public Sprite falseSprite;

	// Use this for initialization
	void Start () {
		t = FindObjectOfType<Temp> ();
//		nameList.Add (t.goalName);
//		nameList.Add (t.lureName [0]);
//		nameList.Add (t.lureName [1]);
	}

	public void CheckJornal(Text name){
		if (j.lists.Count != 0) {
			if (name.text == t.goalName) {
				resultPanel.SetActive (true);
				resultName.text = name.text;
				resultImage = imagePanel.GetComponentInChildren<Image> ();
				resultImage.sprite = trueSprite;
				resultImage.color = new Color32 (143, 235, 22, 255);
				Invoke ("NewGame", 3.0f);
			} else {
				resultPanel.SetActive (true);
				resultName.text = "Not " + name.text;
				resultImage = imagePanel.GetComponentInChildren<Image> ();
				resultImage.sprite = falseSprite;
				resultImage.color = new Color32 (228, 55, 30, 255);
			}
		} else if (j.lists.Count == 0) {
			resultPanel.SetActive (true);
			resultName.text = "You haven't investigate anything.";
			resultImage = imagePanel.GetComponentInChildren<Image> ();
			resultImage.sprite = falseSprite;
			resultImage.color = new Color32 (228, 55, 30, 255);
		}
	}

	void NewGame(){
		GameObject tmp = GameObject.FindGameObjectWithTag ("Temp");
		Destroy (tmp);
		SceneManager.LoadScene (0);
	}
}
