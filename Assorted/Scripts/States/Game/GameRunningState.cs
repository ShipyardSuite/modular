using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shipyard.Modular.FSM.Test
{
	public class GameRunningState : IState
	{
		private FiniteStateMachine stateManager;

		public GameRunningState(FiniteStateMachine stateManager)
		{
			this.stateManager = stateManager;
		}

		public void Execute(float delta)
		{

		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{
			UIManager.Instance.ShowOptionsMenu(false);

			GameManager.Instance.gameTimer.Resume();

			SaveGameManager.Instance.SaveGame();
		}

		public void Exit()
		{

		}
	}
}
