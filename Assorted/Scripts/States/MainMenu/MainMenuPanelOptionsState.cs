using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shipyard.Modular.FSM.State
{
	public class MainMenuPanelOptionsState : IState
	{
		private FiniteStateMachine stateManager;

		public float timerMax = 5;
		public float timer;
		public GameObject panel;
		public MainMenuManager mainMenuManager;
		int currentMenu = 0;

		public MainMenuPanelOptionsState(
			FiniteStateMachine stateManager,
			MainMenuManager mainMenuManager
		)
		{
			this.stateManager = stateManager;
			this.mainMenuManager = mainMenuManager;

			this.panel = mainMenuManager.optionsPanel;
		}

		public void Execute(float delta)
		{
			timer += delta;

			if (timer > timerMax)
			{
				timer = 0;

			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				this.stateManager.ChangeState(new MainMenuPanelMenuState(
					stateManager,
					mainMenuManager
				));
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (currentMenu < 4)
				{
					currentMenu++;
				}
				else
				{
					currentMenu = 0;
				}
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (currentMenu > 0)
				{
					currentMenu--;
				}
				else
				{
					currentMenu = 3;
				}
			}

			switch (currentMenu)
			{
				default:
				case 0:
					mainMenuManager.optionsSubHeaderGame.gameObject.SetActive(true);
					mainMenuManager.optionsSubHeaderAudio.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderVideo.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderControls.gameObject.SetActive(false);
					break;
				case 1:
					mainMenuManager.optionsSubHeaderGame.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderAudio.gameObject.SetActive(true);
					mainMenuManager.optionsSubHeaderVideo.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderControls.gameObject.SetActive(false);
					break;
				case 2:
					mainMenuManager.optionsSubHeaderGame.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderAudio.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderVideo.gameObject.SetActive(true);
					mainMenuManager.optionsSubHeaderControls.gameObject.SetActive(false);
					break;
				case 3:
					mainMenuManager.optionsSubHeaderGame.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderAudio.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderVideo.gameObject.SetActive(false);
					mainMenuManager.optionsSubHeaderControls.gameObject.SetActive(true);
					break;
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
