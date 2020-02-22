using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shipyard.Modular.FSM.State
{
	public class MainMenuPanelWelcomeState : IState
	{
		private FiniteStateMachine stateManager;

		public float timerMax = 5;
		public float timer;
		public GameObject panel;
		public MainMenuManager mainMenuManager;

		public MainMenuPanelWelcomeState(
			FiniteStateMachine stateManager,
			MainMenuManager mainMenuManager
		)
		{
			this.stateManager = stateManager;
			this.mainMenuManager = mainMenuManager;

			this.panel = mainMenuManager.welcomePanel;
		}

		public void Execute(float delta)
		{
			timer += delta;

			if (timer > timerMax)
			{
				timer = 0;
			}

			if (Input.GetKeyDown(KeyCode.Return))
			{
				this.stateManager.ChangeState(new MainMenuAutoSaveMessageState(
					stateManager,
					mainMenuManager
				));
			}
		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{
			panel.SetActive(true);
		}

		public void Exit()
		{
			panel.SetActive(false);
		}
	}
}
