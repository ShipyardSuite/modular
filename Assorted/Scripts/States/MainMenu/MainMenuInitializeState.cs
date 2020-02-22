
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Shipyard.Modular.Helper;
using Shipyard.Modular.SaveGame;

namespace Shipyard.Modular.FSM.State
{
	public class MainMenuInitializeState : IState
	{
		private FiniteStateMachine stateManager;

		public float timerMax = 5;
		public float timer;
		public MainMenuManager mainMenuManager;

		public MainMenuInitializeState(
			FiniteStateMachine stateManager,
			MainMenuManager mainMenuManager
		)
		{
			this.stateManager = stateManager;
			this.mainMenuManager = mainMenuManager;
		}

		public void Execute(float delta)
		{
			timer += delta;


			if (timer > timerMax)
			{
				timer = 0;

				if (mainMenuManager.gamestart)
				{
					this.stateManager.ChangeState(new MainMenuPanelWelcomeState(
						stateManager,
						mainMenuManager
					));
				}
				else if (!mainMenuManager.gamestart)
				{
					this.stateManager.ChangeState(new MainMenuPanelMenuState(
						stateManager,
						mainMenuManager
					));
				}
			}
		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{
			mainMenuManager.saveLoadIndicator.gameObject.SetActive(true);
			mainMenuManager.versionString.gameObject.SetActive(true);

			mainMenuManager.version = Version.GetVersion();
			mainMenuManager.notFirstRun = SaveSystem.SaveFileExists(0);
			mainMenuManager.isOnline = Connection.CheckIfOnline();

			mainMenuManager.saveLoadIndicator.FadeIn();
		}

		public void Exit()
		{
			mainMenuManager.saveLoadIndicator.FadeOut();
		}
	}
}
