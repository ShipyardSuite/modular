using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shipyard.Modular.Base;
using Shipyard.Modular.SaveGame;
using Shipyard.Modular.FSM;
using Shipyard.Modular.FSM.State;

namespace Shipyard.Modular
{
	public class SaveGameManager : SingletonPersistent<SaveGameManager>
	{
		private FiniteStateMachine stateManager = new FiniteStateMachine();

		public int currentBlock = 0;
		public string currentLevel = "Game";

		// Start is called before the first frame update
		void Start()
		{
			this.stateManager.ChangeState(new SaveLoadIdleState(stateManager));
		}

		// Update is called once per frame
		void Update()
		{
			this.stateManager.ExecuteStateUpdate();
		}

		public void LoadGame()
		{
			this.stateManager.ChangeState(new SaveLoadLoadingState(stateManager));
		}

		public void SaveGame()
		{
			this.stateManager.ChangeState(new SaveLoadSavingState(stateManager));
		}
	}
}