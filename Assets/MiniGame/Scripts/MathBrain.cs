using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MathBrain : MonoBehaviour {

	public Text questionText;
	List<string> operations = new List<string>(new string[] {"add", "subtract", "multiply"});
	List<int> answerChoices = new List<int>();
	public GameObject[] buttons = new GameObject[4];
	int answer = -101;
	public Image correct;
	public Image wrong;
	public GameObject miniGamePanel;
	public GameObject itemPic_Panel;
	public GameObject checkMiniGame;
	public Jornal jornal;
	public MasterGameVolumeController mGVC;

	public player player;

	void Start() 
	{
//		buttons = GameObject.FindGameObjectsWithTag("AnswerButton");
//		Debug.Log ("Buttons length"+buttons.Length);
//		Question_Generator();
//		Answer_Generator(answer);
//		Populate_Answer_Buttons();

	}

	public void MiniGameStart(){
		Question_Generator ();
		Answer_Generator (answer);
		Populate_Answer_Buttons ();
	}
	
	// Generates a random (addition, subtraction, or multiplication) question
	public void Question_Generator() {

		// Randomly picking an operation from the list
		string operation = operations[Random.Range(0, 3)]; 
		// Randomly choose 2 numbers
		int num1 = Random.Range(1,10);
		int num2 = Random.Range(1,10);;

		// Based on randomly chosen operation, perform the operation to the 2 numbers
		switch (operation)
		{
			case "add":
				answer = num1 + num2;
				Debug.Log(num1 + " + " + num2);
				questionText.text = num1 + " + " + num2 + " = ?";
				break;
			case "subtract":
				if (num1 > num2) {
					answer = num1 - num2;
					Debug.Log(num1 + " - " + num2);
					questionText.text = num1 + " - " + num2 + " = ?"; 
				} else {
					answer = num2 - num1;
					Debug.Log(num2 + " - " + num1);
					questionText.text = num2 + " - " + num1 + " = ?"; 
				}
				break;
			case "multiply":
				answer = num1 * num2;
				Debug.Log(num1 + " x " + num2);
				questionText.text = num1 + " x " + num2 + " = ?"; 
				break;
			default:
				Debug.Log("No operation chosen");
				break;
		}
		answerChoices.Add(answer);
		Debug.Log("Generated Question");
	}

	// Generate a list of possible answers using the actual answer
	public void Answer_Generator(int correctAnswer) 
	{
		int i = 0;
		while (i < 3) 
		{
			// To randomly choose between addition or subtraction 	
			if (Random.Range(0,2) == 0) 
			{
				// Add a random number to the answer
				int choice = correctAnswer + Random.Range(1, 5);

				while(answerChoices.Contains(choice))
				{
					choice = correctAnswer + Random.Range(1, 5);
				}
				answerChoices.Add(choice);
			} 
			else
			{
				// Subtract a random number from the answer
				int choice = correctAnswer - Random.Range(1, 5);

				while(answerChoices.Contains(choice))
				{
					choice = correctAnswer - Random.Range(1, 5);
				}
				answerChoices.Add(choice);
			}

			i++;
		}
		Debug.Log("Generated Answers");
	}

	// Updates the text of the answer buttons to the answer choices 
	public void Populate_Answer_Buttons()
	{
		//-----adding shuffle algorithm--------
		int i = 0;
		foreach (GameObject btn in buttons)
		{
			Text btnText = btn.GetComponentInChildren<Text>();
			btnText.text = answerChoices[i].ToString();
			i++;
		}
		answerChoices.Clear ();
		Debug.Log("Populated Answer Buttons");
	}

	public void Check_Answer(Button btn)
	{
		GameObject gO = GameObject.Find ("Main Camera");
		PickUpObject pUO = gO.GetComponent<PickUpObject> ();
		Item item = pUO.targer.GetComponent<Item> ();

		if (int.Parse(btn.GetComponentInChildren<Text>().text) == answer) {
			item.thisItem.isMinigame = true;
			btn.GetComponent<Image>().color = Color.green;
			correct.gameObject.SetActive (true);
			mGVC.PlayCorrectSound ();
			Invoke ("Correct", 2.5f);
			jornal.ReceiveNewClue (item.thisItem);
			Debug.Log("Correct Answer");
			player.AddXP (25);
		} else {
			btn.GetComponent<Image>().color = Color.red;
			wrong.gameObject.SetActive (true);
			mGVC.PlayIncorrectSound ();
			Invoke ("Wrong", 2.5f);
		}
	}

	void Correct(){
		correct.gameObject.SetActive (false);
		miniGamePanel.SetActive (false);
		foreach (Transform child in itemPic_Panel.transform) {
			child.gameObject.SetActive (true);
		}
		CheckIsMiniGame check = checkMiniGame.GetComponent<CheckIsMiniGame> ();
		check.CheckMiniGame ();
	}

	void Wrong(){
		wrong.gameObject.SetActive (false);
		miniGamePanel.SetActive (false);
		foreach (Transform child in itemPic_Panel.transform) {
			child.gameObject.SetActive (true);
		}
		CheckIsMiniGame check = checkMiniGame.GetComponent<CheckIsMiniGame> ();
		check.CheckMiniGame ();
	}

}
