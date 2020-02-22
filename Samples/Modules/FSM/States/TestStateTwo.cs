using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Shipyard.Modular.Helper;

namespace Shipyard.Modular.FSM.State
{
	public class TestStateTwo : IState
	{
		private FiniteStateMachine stateManager;
		private string gameModeText;
		private Timer gameTimer;
		private RotateObject testCube;

		public TestStateTwo(FiniteStateMachine stateManager, string gameModeText, Timer gameTimer, RotateObject testCube)
		{
			this.stateManager = stateManager;
			this.gameModeText = gameModeText;
			this.gameTimer = gameTimer;
			this.testCube = testCube;
		}

		public void Execute(float delta)
		{
			Debug.Log("Running Input State 2");

			gameModeText = "Pause";
		}

		public void LateExecute() { }

		public void OnEnter()
		{
			testCube.Stop();
			gameTimer.Stop();
		}

		public void Exit()
		{
			testCube.Resume();
			gameTimer.Resume();
		}
	}
}