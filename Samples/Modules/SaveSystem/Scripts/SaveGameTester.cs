using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Shipyard.Modular.Internationalization;
using Shipyard.Modular.SaveGame;

namespace Shipyard.Modular.Demo
{
	public class SaveGameTester : MonoBehaviour
	{
		public Languages defaultLanguage;

		public Text saveGameButtonText;
		public Text loadGameButtonText;
		public Text deleteGameButtonText;
		public Text infoHeaderText;
		public Text infoTimeStampText;
		public Text infoTestStringText;
		public Text infoPlayerPositionText;
		public Text timeStampText;
		public Text testStringText;
		public Text playerPositionText;

		public GameObject saveGamePanel;

		public Button saveGameButton;
		public Button loadGameButton;
		public Button deleteGameButton;

		public GameObject testCube;

		public i18n converter;

		PlayerData currentPlayerData = new PlayerData();
		GameData loadedPlayerData;

		// Start is called before the first frame update
		void Start()
		{
			converter = new i18n(defaultLanguage, "savegame");
			currentPlayerData.testString = "ASDF";
		}

		// Update is called once per frame
		void Update()
		{
			converter.language = defaultLanguage;

			bool doesExist = SaveSystem.SaveFileExists(0);

			saveGameButtonText.text = converter.GetMessage("test.saveGame.saveGameButton");
			loadGameButtonText.text = converter.GetMessage("test.saveGame.loadGameButton");
			deleteGameButtonText.text = converter.GetMessage("test.saveGame.deleteGameButton");
			infoHeaderText.text = converter.GetMessage("test.saveGame.infoHeader");
			infoTimeStampText.text = converter.GetMessage("test.saveGame.infoTimeStamp");
			infoTestStringText.text = converter.GetMessage("test.saveGame.infoTestString");
			infoPlayerPositionText.text = converter.GetMessage("test.saveGame.infoPlayerPosition");

			if (doesExist)
			{
				loadGameButton.interactable = true;
				deleteGameButton.interactable = true;

				saveGamePanel.SetActive(true);
			}
			else
			{
				loadGameButton.interactable = false;
				deleteGameButton.interactable = false;

				saveGamePanel.SetActive(false);
			}
		}

		public void SaveGame()
		{
			currentPlayerData.timestamp = DateTime.Now;
			currentPlayerData.playerPosition = testCube.transform.position;

			SaveSystem.SaveGame(currentPlayerData, 0);

			LoadGame();
		}

		public void LoadGame()
		{
			loadedPlayerData = SaveSystem.LoadGame(0);

			timeStampText.text = converter.DateTime(loadedPlayerData.timestamp);
			testStringText.text = loadedPlayerData.testString;
			playerPositionText.text = new Vector3(loadedPlayerData.playerPosition[0], loadedPlayerData.playerPosition[1], loadedPlayerData.playerPosition[2]).ToString();

			testCube.transform.position = new Vector3(loadedPlayerData.playerPosition[0], loadedPlayerData.playerPosition[1], loadedPlayerData.playerPosition[2]);
		}

		public void DeleteGame()
		{
			SaveSystem.DeleteSaveGame(0);
		}
	}
}

