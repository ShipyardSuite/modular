using UnityEngine;

namespace Shipyard.Modular.FSM
{
	public interface IState
	{
		void OnEnter();
		void Execute(float delta);
		void LateExecute();
		void Exit();
	}
}