using System;
using UnityEngine;

namespace Shipyard.Modular.SaveGame
{
	[System.Serializable]
	public class GameData
	{
		public DateTime timestamp;
		public string testString;
		public float progress;
		public float[] playerPosition;

		public GameData(PlayerData playerData)
		{
			timestamp = playerData.timestamp;
			testString = playerData.testString;
			progress = playerData.progress;

			playerPosition = new float[3];
			playerPosition[0] = playerData.playerPosition.x;
			playerPosition[1] = playerData.playerPosition.y;
			playerPosition[2] = playerData.playerPosition.z;
		}

	}
}
