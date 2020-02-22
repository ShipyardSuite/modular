using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shipyard.Modular.FSM.Test
{
	public class GamePauseState : IState
	{
		private FiniteStateMachine stateManager;

		public GamePauseState(FiniteStateMachine stateManager)
		{
			this.stateManager = stateManager;
		}

		public void Execute(float delta)
		{
			if (!GameManager.Instance.gamePauseMode)
			{

			}
		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{
			UIManager.Instance.ShowOptionsMenu(true);

			GameManager.Instance.gameTimer.Stop();
		}

		public void Exit()
		{

		}
	}
}
