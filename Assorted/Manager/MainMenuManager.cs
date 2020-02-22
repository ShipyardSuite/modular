using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

using Shipyard.Modular.FSM;
using Shipyard.Modular.FSM.State;
using Shipyard.Modular.Internationalization;
using Shipyard.Modular.Helper;
using Shipyard.Modular.UI;

namespace Shipyard.Modular
{
	public class MainMenuManager : MonoBehaviour
	{
		private FiniteStateMachine stateManager = new FiniteStateMachine();
		private i18n converter = new i18n();

		public Languages language;
		public GameObject welcomePanel;
		public GameObject autoSaveMessagePanel;
		public GameObject menuPanel;
		public GameObject optionsPanel;
		public LoadingScreen loadingScreen;

		public SaveLoadIndicator saveLoadIndicator;
		public SaveLoadIndicator saveLoadIndicatorMessage;

		public TMP_Text versionString;
		public TMP_Text startGameString;

		public Button menuNewGameButton;
		public Button menuContinueButton;
		public Button menuOptionsGameButton;

		public TMP_Text autoSaveMessage;

		public TMP_Text optionsHeader;
		public TMP_Text optionsSubHeaderGame;
		public TMP_Text optionsSubHeaderAudio;
		public TMP_Text optionsSubHeaderVideo;
		public TMP_Text optionsSubHeaderControls;
		public TMP_Text optionsFooter;

		public bool gamestart = true;
		public bool notFirstRun;
		public bool isOnline;

		public string version;

		// Start is called before the first frame update
		void Start()
		{
			this.stateManager.ChangeState(new MainMenuInitializeState(
				stateManager,
				this
			));
		}

		// Update is called once per frame
		void Update()
		{
			converter.language = language;

			this.stateManager.ExecuteStateUpdate();

			versionString.text = converter.GetMessage("game.menu.versionInfo", version != "" ? version : "");
			startGameString.text = converter.GetMessage("game.menu.welcome.startGame");

			autoSaveMessage.text = converter.GetMessage("game.menu.autosave.message");

			menuNewGameButton.GetComponentInChildren<TMP_Text>().text = converter.GetMessage("game.menu.main.menuNewGameButton");
			menuContinueButton.GetComponentInChildren<TMP_Text>().text = converter.GetMessage("game.menu.main.menuContinueButton");
			menuOptionsGameButton.GetComponentInChildren<TMP_Text>().text = converter.GetMessage("game.menu.main.menuOptionsGameButton");

			optionsHeader.text = converter.GetMessage("game.menu.options.header");
			optionsSubHeaderGame.text = converter.GetMessage("game.menu.options.subHeaderGame");
			optionsSubHeaderAudio.text = converter.GetMessage("game.menu.options.subHeaderAudio");
			optionsSubHeaderVideo.text = converter.GetMessage("game.menu.options.subHeaderVideo");
			optionsSubHeaderControls.text = converter.GetMessage("game.menu.options.subheaderControls");
			optionsFooter.text = converter.GetMessage("game.menu.options.footer");
		}

		public void OpenNewGame()
		{

			StartCoroutine(OpenNewGameRoutine());
		}

		public void ContinueGame()
		{

			StartCoroutine(ContinueGameRoutine());
		}

		private IEnumerator OpenNewGameRoutine()
		{
			loadingScreen.FadeIn();
			yield return new WaitForSeconds(1.0f);
			Debug.Log("Test");
			SceneManager.LoadScene("Game");
		}

		private IEnumerator ContinueGameRoutine()
		{
			loadingScreen.FadeIn();
			yield return new WaitForSeconds(1.0f);
			Debug.Log("Test");
			SceneManager.LoadScene(SaveGameManager.Instance.currentLevel);
		}
	}
}
