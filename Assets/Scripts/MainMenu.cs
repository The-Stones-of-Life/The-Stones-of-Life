using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TerrainEngine2D;
using ModTool;
using System;
using System.IO;

public class MainMenu : MonoBehaviour
{
	public WorldData WorldData;

	public bool modMenuOpen = false;
	public GameObject modMenu;

	public ModManager manager;

	void Start()
    {

		manager = ModManager.instance;

		string dataFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/tsolData";

		if (!Directory.Exists(dataFolder))
        {
			Directory.CreateDirectory(dataFolder);
			if (!Directory.Exists(dataFolder + "/mods"))
            {
				Directory.CreateDirectory(dataFolder + "/mods");
				manager.AddSearchDirectory(dataFolder + "/mods");
			}
		}

		if (Directory.Exists(dataFolder + "/mods")) {
			manager.AddSearchDirectory(dataFolder + "/mods");
		}
    }

	void Update()
    {
		if (modMenuOpen && Input.GetKeyDown(KeyCode.Escape))
        {
			modMenuOpen = false;
			modMenu.SetActive(false);
        }
    }

	public void PlayGame(string name) {
		
		WorldData.LoadWorld = false;
        WorldData.SaveWorld = false;
		WorldData.Seed = UnityEngine.Random.Range(int.MinValue / 100, int.MaxValue / 100);
		WorldData.Name = name;
		SceneManager.LoadScene(1);
		
	}

	public void PlayMultiplayerGame()
	{
		SceneManager.LoadScene(2);
	}

	public void OpenModMenu(string name)
	{
		modMenuOpen = true;
		modMenu.SetActive(true);
	}
}
