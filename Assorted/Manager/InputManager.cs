using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shipyard.Modular.Base;

namespace Shipyard.Modular
{
	public class InputManager : SingletonPersistent<InputManager>
	{
		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			if (GameManager.Instance.gameMode == "GameRunningState")
			{
				GameRunningInput();
			}

			if (GameManager.Instance.gameMode == "GamePauseState")
			{
				GamePauseInput();
			}
		}

		void GameRunningInput()
		{
			Debug.Log("Running");
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GameManager.Instance.gamePauseMode = true;
			}
		}

		void GamePauseInput()
		{
			Debug.Log("Pause");
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GameManager.Instance.gamePauseMode = false;
			}
		}

	}
}
