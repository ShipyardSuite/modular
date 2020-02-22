using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Shipyard.Modular.Helper;

namespace Shipyard.Modular.FSM.State
{
	public class TestStateOne : IState
	{
		private FiniteStateMachine stateManager;
		private string gameModeText;

		public TestStateOne(FiniteStateMachine stateManager, string gameModeText)
		{
			this.stateManager = stateManager;
			this.gameModeText = gameModeText;
		}

		public void Execute(float delta)
		{
			Debug.Log("Running Test State 1");

			gameModeText = "Game";
		}

		public void LateExecute() { }

		public void OnEnter() { }

		public void Exit() { }
	}
}