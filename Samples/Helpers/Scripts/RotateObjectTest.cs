using UnityEngine;
using TMPro;

using Shipyard.Modular.Helper;
using Shipyard.Modular.Internationalization;

namespace Shipyard.Modular.Helper
{
	public class RotateObjectTest : MonoBehaviour
	{
		public i18n converter;
		public Languages language;
		public TMP_Text resumeButtonText;
		public TMP_Text pauseButtonText;

		// Start is called before the first frame update
		void Start()
		{
			converter = new i18n(language, "helpers");
		}

		// Update is called once per frame
		void Update()
		{
			converter.language = language;

			resumeButtonText.text = converter.GetMessage("test.helpers.rotateObject.resumeRotationButton");
			pauseButtonText.text = converter.GetMessage("test.helpers.rotateObject.pauseRotationButton");
		}
	}
}
