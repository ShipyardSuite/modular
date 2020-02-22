using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Shipyard.Modular.Base;
using Shipyard.Modular.Internationalization;
using Shipyard.Modular.Helper;

namespace Shipyard.Modular
{
	public class UIManager : SingletonPersistent<UIManager>
	{
		public i18n converter = new i18n();

		[Header("DebugPanel")]
		public TMP_Text debugGameModeText;
		public TMP_Text debugGameTimeText;

		[Header("PauseMenuPanel")]
		public GameObject GamePausePanel;

		[Header("GUI")]
		public SaveLoadIndicator saveLoadIndicator;

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			converter.language = GameManager.Instance.gameLanguage;

			UpdateDebugPanel();
		}

		void UpdateDebugPanel()
		{
			debugGameTimeText.text = converter.GetMessage("game.debug.gameTime", converter.secondsToTime(GameManager.Instance.gameTime));
			debugGameModeText.text = converter.GetMessage("game.debug.gameMode", GameManager.Instance.gameMode);
		}

		public void ShowOptionsMenu(bool isVisible)
		{
			GamePausePanel.SetActive(isVisible);
		}

		void PopulateWelcomeScreen()
		{

		}
	}
}