using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour {
	private int xp;
	public Text LevelText;
	public Text expText;
	public Image expGauge;
	private int level = 1;

	public void AddXP(int increase) {
		xp += increase;
		
		if (xp % 100 == 0 && level<100) { // Level up if passes 100
			level++;
		}
		UpdateText();
		Save();
	}

	public void Save()
	{
		PlayerPrefs.SetInt("XP", xp);
		PlayerPrefs.SetInt("Level", level);
	}

	public void Load()
	{
		if (PlayerPrefs.HasKey("XP"))
		{
			xp = PlayerPrefs.GetInt("XP");
			level = PlayerPrefs.GetInt("Level");
			UpdateText();
		}
	}

	private void UpdateText(){
		LevelText.text = level.ToString ();
		int exp = xp % 100;
		if (level < 100) {
			switch (exp) {
			case 25:
				expGauge.fillAmount = 0.25f;
				break;
			case 50:
				expGauge.fillAmount = 0.50f;
				break;
			case 75:
				expGauge.fillAmount = 0.75f;
				break;
			case 100:
				expGauge.fillAmount = 1f;
				break;
			default:
				expGauge.fillAmount = 0f;
				break;
			}
		} else {
			expGauge.fillAmount = 1f;
		}
	}

	public void Reset()
	{
		PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetInt("XP", 0);
//		PlayerPrefs.SetInt("Level", 1);
		UpdateText();
	}
}
