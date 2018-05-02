using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternBrain : MonoBehaviour
{
    float timeBetweenCubes = 1.0f; // Time between each cube glowing
	bool waiting = false;
    public List<GameObject> allCubes = new List<GameObject>(); // List to store all the cubes in the scene
    public List<GameObject> patternCubes = new List<GameObject>(); // Cubes in the pattern
    public List<GameObject> answerCubes = new List<GameObject>(); // To store the cubes that the user clicks
    public List<GameObject> buttons = new List<GameObject>(); // Buttons in scene
    public string answer = ""; // Answer in a string format
    public string guess = "";
    public int cubeNumber = 0;

    public int clickNumber = 0;

	public bool isCorrect;

	public Image correct;
	public Image wrong;
	public GameObject miniGamePanel;
	public GameObject itemPic_Panel;
	public GameObject checkMiniGame;
	public Jornal jornal;
	public MasterGameVolumeController mGVC;

    void Start()
    {
//         foreach (GameObject buttonObj in GameObject.FindGameObjectsWithTag("ColorButton"))   // Finding all buttons
//        {
//            buttons.Add(buttonObj);
//        }
//        DisableItems();
//        FindCubes();
//        CubesInPattern();
//		GlowCubes();
    }

	public void MiniGameStart(){
		guess = "";
		answer = "";
		cubeNumber = 0;
		clickNumber = 0;
		waiting = false;
		allCubes.Clear ();
		buttons.Clear ();
		patternCubes.Clear ();
		answerCubes.Clear ();
		FindButns ();
		DisableItems();
		FindCubes();
		CubesInPattern();
		GlowCubes();
	}

	void FindButns(){
		foreach (GameObject buttonObj in GameObject.FindGameObjectsWithTag("ColorButton")) {   // Finding all buttons
			buttons.Add (buttonObj);
		}
	}

    // Find all cubes in the scene
     void FindCubes()
    {
        foreach (GameObject cubeObj in GameObject.FindGameObjectsWithTag("ColorCube"))
        {
            allCubes.Add(cubeObj);
        }
    }

    // Find all colour buttons and disable them
    void DisableItems()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    void ActivateButtons()
    {
        // Activate all buttons on screen
        foreach(GameObject btn in buttons)
        {
            btn.SetActive(true);
        }
    }

    // Randomly pick 4 distinct cubes
    void CubesInPattern()
    {
        int numberOfCubes = 4; 

       for (int i = 0; i < numberOfCubes; i++)
        {
            int randomNumber = Random.Range(0, allCubes.Count);

            while(patternCubes.Contains(allCubes[randomNumber]))
            {
                randomNumber = Random.Range(0, allCubes.Count);
            }
            patternCubes.Add(allCubes[randomNumber]);
        }
        
    }

	void GlowCubes()
	{
		StartCoroutine(WaitToGlow(cubeNumber));
	}

    void Glow() 
    {
        // Debug.Log(patternCubes[cubeNumber].name + " is glowing");
        patternCubes[cubeNumber].GetComponent<Glow>().GlowCube();
        cubeNumber++;
        if (cubeNumber < 4) {
            GlowCubes();
        } else {
            Debug.Log("Finished glowing pattern");
            ActivateButtons();
            print("Cubes to answer: ");
            foreach(GameObject cube in patternCubes){
                answer = answer + cube.name.Split(' ')[0];
            }
            print(answer);
        }
    }

    IEnumerator WaitToGlow(int cubeNumber)
    {	
        yield return new WaitForSeconds(timeBetweenCubes);
        Glow();
		waiting = true;
    }

    public void ButtonClick(GameObject btn){

        clickNumber++;
        string color = btn.name.Split(' ')[0];
        GameObject cube = GameObject.Find(color + " Cube");
        cube.GetComponent<Glow>().GlowCube();
        if (clickNumber == 4)
        {
            answerCubes.Add(cube);
            Debug.Log("Max Cubes Reached");
            DisableItems();
            CheckAnswerV2();
			CheckAnswer ();
			ActivateButtons ();
        }
        answerCubes.Add(cube);
    }

	void CheckAnswerV2()
	{
		isCorrect = true;
		for(int i=0; i < 4; i++ )
		{
			if (answerCubes[i].name != patternCubes[i].name)
			{
				isCorrect = false;
				break;
			}
		}
	}


    void CheckAnswer()
    {
		GameObject gO = GameObject.Find ("Main Camera");
		PickUpObject pUO = gO.GetComponent<PickUpObject> ();
		Item item = pUO.targer.GetComponent<Item> ();

		if (isCorrect == true) {
			item.thisItem.isMinigame = true;
			correct.gameObject.SetActive (true);
			mGVC.PlayCorrectSound ();
			Invoke ("Correct", 2.5f);
			jornal.ReceiveNewClue (item.thisItem);
		} else {
			wrong.gameObject.SetActive (true);
			mGVC.PlayIncorrectSound ();
			Invoke ("Wrong", 2.5f);
		}
        Debug.Log("Your guess is " + isCorrect);
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
