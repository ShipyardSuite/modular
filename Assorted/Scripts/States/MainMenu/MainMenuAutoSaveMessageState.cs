
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Shipyard.Modular.Helper;
using Shipyard.Modular.SaveGame;

namespace Shipyard.Modular.FSM.State
{
	public class MainMenuAutoSaveMessageState : IState
	{
		private FiniteStateMachine stateManager;

		public float timerMax = 10;
		public float timer;
		public MainMenuManager mainMenuManager;
		public GameObject panel;

		public MainMenuAutoSaveMessageState(
			FiniteStateMachine stateManager,
			MainMenuManager mainMenuManager
		)
		{
			this.stateManager = stateManager;
			this.mainMenuManager = mainMenuManager;

			this.panel = mainMenuManager.autoSaveMessagePanel;
		}

		public void Execute(float delta)
		{
			timer += delta;


			if (timer > timerMax)
			{
				timer = 0;

				if (mainMenuManager.notFirstRun)
				{
					this.stateManager.ChangeState(new MainMenuPanelMenuState(
						stateManager,
						mainMenuManager
					));
				}
				else
				{
					mainMenuManager.OpenNewGame();
				}
			}
		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{
			panel.SetActive(true);
			mainMenuManager.saveLoadIndicatorMessage.FadeIn();
		}

		public void Exit()
		{
			panel.SetActive(false);
			mainMenuManager.saveLoadIndicatorMessage.FadeIn();
		}
	}
}
