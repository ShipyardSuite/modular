using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Shipyard.Modular.FSM.State
{
	public class MainMenuPanelMenuState : IState
	{
		private FiniteStateMachine stateManager;

		public float timerMax = 5;
		public float timer;
		public GameObject panel;
		public MainMenuManager mainMenuManager;

		bool gameStart = false;

		public MainMenuPanelMenuState(
			FiniteStateMachine stateManager,
			MainMenuManager mainMenuManager
		)
		{
			this.stateManager = stateManager;
			this.mainMenuManager = mainMenuManager;

			this.panel = mainMenuManager.menuPanel;
		}

		public void Execute(float delta)
		{
			if (gameStart)
			{
				timer += delta;

				if (timer > timerMax)
				{
					timer = 0;


				}
			}
		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{
			panel.SetActive(true);

			if (mainMenuManager.notFirstRun)
			{
				mainMenuManager.menuContinueButton.enabled = true;
				mainMenuManager.menuContinueButton.Select();

			}
			else
			{
				mainMenuManager.menuContinueButton.enabled = false;
				mainMenuManager.menuNewGameButton.Select();
			}

			mainMenuManager.menuContinueButton.onClick.AddListener(() =>
			{
				mainMenuManager.OpenNewGame();
			});
			mainMenuManager.menuContinueButton.onClick.AddListener(() =>
			{
				mainMenuManager.ContinueGame();
			});
			mainMenuManager.menuOptionsGameButton.onClick.AddListener(() =>
			{
				OpenOptionsMenu();
			});
		}

		public void Exit()
		{
			panel.SetActive(false);
		}

		void OpenOptionsMenu()
		{
			this.stateManager.ChangeState(new MainMenuPanelOptionsState(
				stateManager,
				mainMenuManager
			));
		}
	}
}
