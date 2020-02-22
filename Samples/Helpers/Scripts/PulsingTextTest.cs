using UnityEngine;
using UnityEngine.UI;

using Shipyard.Modular.Internationalization;

namespace Shipyard.Modular.Helper
{
	public class PulsingTextTest : MonoBehaviour
	{
		public i18n converter;
		public Languages language;
		public Text testString;

		private void Start()
		{
			converter = new i18n(language, "helpers");
		}

		void Update()
		{
			converter.language = language;

			testString.text = converter.GetMessage("test.helpers.pulseText.testString");
		}
	}
}
