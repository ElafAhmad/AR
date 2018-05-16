using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {

	public player player;
	public MasterGameVolumeController masterGame;

	private void Awake() {
		LoadGame();
	}
	public void SaveGame()
	{
		player.Save();
		masterGame.Save();
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
	}
}
