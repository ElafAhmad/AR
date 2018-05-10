using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMainMenu : MonoBehaviour {

	public MasterVolumeController master;

	public void ResetSaveData(){
		PlayerPrefs.SetInt ("XP", 0);
		PlayerPrefs.SetInt ("Level", 1);
	}
	
	public void SaveGame()
		{
		
			master.Save();
		}

		public void LoadGame()
		{
			if (PlayerPrefs.HasKey("MusicMute"))
			{
				master.Load();
			}
		}
}
