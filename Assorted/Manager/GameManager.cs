using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Shipyard.Modular.Base;
using Shipyard.Modular.Helper;
using Shipyard.Modular.FSM;
using Shipyard.Modular.FSM.Test;
using Shipyard.Modular.Internationalization;

namespace Shipyard.Modular
{
	public class GameManager : SingletonPersistent<GameManager>
	{
		private FiniteStateMachine stateManager = new FiniteStateMachine();

		public bool debugMode;
		public bool gamePauseMode;
		public string gameMode;
		public float gameTime;
		public Timer gameTimer;
		public Languages gameLanguage;

		void Start()
		{
			this.stateManager.DebugMode(debugMode);

			gameTimer = new Timer();

			this.stateManager.ChangeState(new GamePrepareState(stateManager));
		}

		// Update is called once per frame
		void Update()
		{
			this.stateManager.ExecuteStateUpdate();

			gameMode = stateManager.GetCurrentStateName();
			gameTime = gameTimer.elapsed;
		}
	}
}
