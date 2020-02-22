using System.Collections.Generic;
using UnityEngine;

using Shipyard.Modular.Extension;

namespace Shipyard.Modular.Test
{
	public class ListExtensionsTester : MonoBehaviour
	{
		public List<string> testList = new List<string>();

		public string randomItem;

		//Shuffle
		//RandomItem
		//RemoveRange

		// Start is called before the first frame update
		void Start()
		{
			testList.Add("Hello World 1");
			testList.Add("Hello World 2");
			testList.Add("Hello World 3");
			testList.Add("Hello World 4");
			testList.Add("Hello World 5");
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void ShuffleList()
		{
			testList.Shuffle();
		}

		public void RandomItem()
		{
			randomItem = testList.RandomItem();
		}

		public void RemoveRange()
		{
			testList.RemoveRange(2, 2);
		}
	}
}

