using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Shipyard.Modular.SaveGame
{
	public static class SaveSystem
	{
		public static bool SaveFileExists(int block)
		{
			string path = Application.persistentDataPath + $"/saveGame_{ block }.sgm";

			return File.Exists(path);
		}

		public static void SaveGame(PlayerData playerData, int block)
		{
			BinaryFormatter formatter = new BinaryFormatter();

			string path = Application.persistentDataPath + $"/saveGame_{ block }.sgm";

			FileStream stream = new FileStream(path, FileMode.Create);

			GameData data = new GameData(playerData);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static GameData LoadGame(int block)
		{
			string path = Application.persistentDataPath + $"/saveGame_{ block }.sgm";

			if (File.Exists(path))
			{
				BinaryFormatter formatter = new BinaryFormatter();

				FileStream stream = new FileStream(path, FileMode.Open);

				GameData data = formatter.Deserialize(stream) as GameData;
				stream.Close();

				return data;
			}
			else
			{
				return null;
			}
		}

		public static void DeleteSaveGame(int block)
		{
			string path = Application.persistentDataPath + $"/saveGame_{ block }.sgm";

			File.Delete(path);
		}
	}
}