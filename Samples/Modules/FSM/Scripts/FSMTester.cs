using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using Shipyard.Modular.FSM;
using Shipyard.Modular.FSM.State;
using Shipyard.Modular.Helper;
using Shipyard.Modular.Internationalization;

namespace Shipyard.Modular.Test
{
	public class FSMTester : MonoBehaviour
	{
		private FiniteStateMachine stateManager = new FiniteStateMachine();
		private Timer gameTimer;

		public string gameStateString;

		public Languages language;
		public i18n converter;

		public Button firstButton;
		public Text gameModeText;
		public Text gameTimeText;
		public Text resumeButtonText;
		public Text pauseButtonText;
		public RotateObject testCube;


		// Start is called before the first frame update
		void Start()
		{
			converter = new i18n(language, "fsm");

			gameTimer = new Timer();

			firstButton.Select();

			setTestStateOne();
		}

		// Update is called once per frame
		void Update()
		{
			converter.language = language;

			this.stateManager.ExecuteStateUpdate();

			gameModeText.text = converter.GetMessage("test.fsm.gameModeString", gameStateString);
			gameTimeText.text = converter.GetMessage("test.fsm.gameTimeString", converter.secondsToTime(gameTimer.elapsed));
			resumeButtonText.text = converter.GetMessage("test.fsm.gameStateButton");
			pauseButtonText.text = converter.GetMessage("test.fsm.pauseStateButton");

		}

		public void setTestStateOne()
		{
			this.stateManager.ChangeState(new TestStateOne(stateManager, gameStateString));
		}

		public void setTestStateTwo()
		{
			this.stateManager.ChangeState(new TestStateTwo(stateManager, gameStateString, gameTimer, testCube));
		}
	}
}
