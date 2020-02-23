﻿using System.Linq;
using UnityEngine;

namespace Shipyard.Modular.Helper
{
	public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
	{
		private static T _instance = null;

		public static T instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
				}

				return _instance;
			}
		}
	}
}
