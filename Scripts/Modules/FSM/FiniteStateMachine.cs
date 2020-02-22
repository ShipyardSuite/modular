
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shipyard.Modular;

namespace Shipyard.Modular.FSM
{
	public class FiniteStateMachine : MonoBehaviour
	{
		private IState currentState;
		private IState defaultState;
		private bool showDebugInfo;

		private void Update()
		{
			if (currentState != null)
			{
				currentState.Execute(Time.deltaTime);
			}
		}

		public void DebugMode(bool active)
		{
			showDebugInfo = active;
		}

		private void LateUpdate()
		{
			if (currentState != null)
			{
				currentState.LateExecute();
			}
		}

		public void ExecuteStateUpdate()
		{
			this.currentState.Execute(Time.deltaTime);

			if (showDebugInfo) Debug.Log("Running State -> " + GetCurrentStateName());
		}

		public void ExecuteLateStateUpdate()
		{
			this.currentState.LateExecute();
		}

		public void ShowDebugInfo(bool showInfo)
		{
			showDebugInfo = showInfo;
		}

		public void ChangeState(IState targetState)
		{
			if (currentState != null)
			{
				if (showDebugInfo) Debug.Log("Exiting State -> " + GetCurrentStateName());
				currentState.Exit();
			}

			currentState = targetState;

			if (currentState != null)
			{
				if (showDebugInfo) Debug.Log("Entering State -> " + GetCurrentStateName());
				currentState.OnEnter();
			}
		}

		public void BackToDefaultState()
		{
			ChangeState(defaultState);
		}



		public String GetCurrentStateName()
		{
			return currentState.GetType().Name;
		}
	}
}
