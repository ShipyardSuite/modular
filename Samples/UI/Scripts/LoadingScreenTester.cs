using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shipyard.Modular.UI;

namespace Shipyard.Modular.Demo
{
	public class LoadingScreenTester : MonoBehaviour
	{
		public LoadingScreen loadingScreen;

		public bool visible;
		public int num;

		// Start is called before the first frame update
		void Start()
		{
			num = Random.Range(0, 4);

			loadingScreen.Populate(num);
		}

		// Update is called once per frame
		void Update()
		{
			loadingScreen.FadeIn();
		}
	}
}
