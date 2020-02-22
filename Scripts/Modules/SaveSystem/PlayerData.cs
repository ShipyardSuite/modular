using System;
using UnityEngine;

namespace Shipyard.Modular.SaveGame
{
	[System.Serializable]
	public class PlayerData
	{
		public DateTime timestamp = DateTime.Now;
		public string testString = "saveTest";
		public float progress = 0.0f;
		public Vector3 playerPosition = new Vector3(3.0f, 0.0f, 3.0f);
	}
}
