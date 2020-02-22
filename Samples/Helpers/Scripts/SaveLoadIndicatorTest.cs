using UnityEngine;
using UnityEngine.UI;

using Shipyard.Modular.Helper;
using Shipyard.Modular.Internationalization;

namespace Shipyard.Modular.Helper
{
	public class SaveLoadIndicatorTest : MonoBehaviour
	{
		public i18n converter;
		public Languages language;
		public Text fadeInButtonText;
		public Text fadeOutButtonText;

		// Start is called before the first frame update
		void Start()
		{
			converter = new i18n(language, "helpers");
		}

		// Update is called once per frame
		void Update()
		{
			fadeInButtonText.text = converter.GetMessage("test.helpers.saveLoadIndicator.fadeInButton");
			fadeOutButtonText.text = converter.GetMessage("test.helpers.saveLoadIndicator.fadeOutButton");

			converter.language = language;
		}
	}
}