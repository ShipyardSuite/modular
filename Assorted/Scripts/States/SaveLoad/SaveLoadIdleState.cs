using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shipyard.Modular.FSM.State
{
	public class SaveLoadIdleState : IState
	{
		private FiniteStateMachine stateManager;

		public float timerMax = 5;
		public float timer;

		public SaveLoadIdleState(FiniteStateMachine stateManager)
		{
			this.stateManager = stateManager;
		}

		public void Execute(float delta)
		{
			timer += delta;

			if (timer > timerMax)
			{
				timer = 0;

			}
		}

		public void LateExecute()
		{

		}

		public void OnEnter()
		{

		}

		public void Exit()
		{

		}
	}
}
