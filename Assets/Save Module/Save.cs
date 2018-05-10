using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {

	public player player;
	public MasterGameVolumeController masterGame;
	// public MasterVolumeController master;

	private void Awake() {
		LoadGame();
	}
	public void SaveGame()
	{
		player.Save();
		masterGame.Save();
		// master.Save();
	}

	public void LoadGame()
	{
		if(PlayerPrefs.HasKey("XP")) {
			player.Load();
		}
		if (PlayerPrefs.HasKey("MusicGameMute"))
		{
			masterGame.Load();
		}

		// if (PlayerPrefs.HasKey("MusicMute"))
		// {
		// 	master.Load();
		// }
	}
}
