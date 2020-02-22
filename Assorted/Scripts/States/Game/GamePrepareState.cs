using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shipyard.Modular.FSM.Test
{
	public class GamePrepareState : IState
	{
		private FiniteStateMachine stateManager;

		public float timerMax = 5;
		public float timer;

		public GamePrepareState(FiniteStateMachine stateManager)
		{
			this.stateManager = stateManager;
		}

		public void Execute(float delta)
		{
			timer += delta;

			if (timer > timerMax)
			{
				timer = 0;

				this.stateManager.ChangeState(new GameRunningState(stateManager));
			}

		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{
			GameManager.Instance.gameTimer.Stop();
		}

		public void Exit()
		{

		}
	}
}
