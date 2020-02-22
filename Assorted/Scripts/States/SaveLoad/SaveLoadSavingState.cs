using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shipyard.Modular.FSM.State
{
	public class SaveLoadSavingState : IState
	{
		private FiniteStateMachine stateManager;

		public float timerMax = 5;
		public float timer;

		public SaveLoadSavingState(FiniteStateMachine stateManager)
		{
			this.stateManager = stateManager;
		}

		public void Execute(float delta)
		{
			timer += delta;

			if (timer > timerMax)
			{
				timer = 0;

				this.stateManager.ChangeState(new SaveLoadIdleState(stateManager));

			}
		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{
			UIManager.Instance.saveLoadIndicator.FadeIn();
		}

		public void Exit()
		{
			UIManager.Instance.saveLoadIndicator.FadeOut();
		}
	}
}
