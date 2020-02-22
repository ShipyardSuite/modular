using UnityEngine;
using UnityEngine.UI;

using Shipyard.Modular.Internationalization;

namespace Shipyard.Modular.Test
{
	public class i18nDemo : MonoBehaviour
	{
		public Languages defaultLanguage;

		public string stringValueInput;
		public int intValueInput;
		public float floatValueInput;
		public float secondsToTimeInput;
		[Range(0, 24)] public int hourInput;

		public Text stringToValueOutput;
		public Text valuetoStringIntOutput;
		public Text valueToStringFloatOutput;
		public Text TwelveHourClockOutput;
		public Text TwentyFourHourClockOutput;
		public Text gameTimeOutput;
		public Text testStringOutput;

		public Text valuesHeader;
		public Text timeHeader;
		public Text stringToValueTitle;
		public Text valuetoStringIntTitle;
		public Text valueToStringFloatTitle;
		public Text TwelveHourClockTitle;
		public Text TwentyFourHourClockTitle;
		public Text gameTimeTitle;

		public Text languageGermanButtonText;
		public Text languageEnglishButtonText;

		public Button languageGermanButton;

		public i18n converter;

		// Start is called before the first frame update
		void Start()
		{
			converter = new i18n(defaultLanguage, "i18n");
			languageGermanButton.Select();
		}

		// Update is called once per frame
		void Update()
		{
			converter.language = defaultLanguage;

			secondsToTimeInput = Time.time;

			stringToValueOutput.text = converter.StringToValue(stringValueInput).ToString();
			valuetoStringIntOutput.text = converter.ValueToString(intValueInput);
			valueToStringFloatOutput.text = converter.ValueToString(floatValueInput);

			TwelveHourClockOutput.text = converter.HoursToClock(hourInput, 12);
			TwentyFourHourClockOutput.text = converter.HoursToClock(hourInput, 24);
			gameTimeOutput.text = converter.secondsToTime(secondsToTimeInput);

			testStringOutput.text = converter.GetMessage("test.i18n.testString", Random.Range(100, 500).ToString());

			valuesHeader.text = converter.GetMessage("test.i18n.values");
			timeHeader.text = converter.GetMessage("test.i18n.time");
			stringToValueTitle.text = converter.GetMessage("test.i18n.stringToValue");
			valuetoStringIntTitle.text = converter.GetMessage("test.i18n.valueToIntString");
			valueToStringFloatTitle.text = converter.GetMessage("test.i18n.valueToFloatString");
			TwelveHourClockTitle.text = converter.GetMessage("test.i18n.twelveHourClock");
			TwentyFourHourClockTitle.text = converter.GetMessage("test.i18n.twentyFourHourClock");
			gameTimeTitle.text = converter.GetMessage("game.modules.i18n.secondsToTime");

			languageGermanButtonText.text = converter.GetMessage("test.i18n.languageGermanButton");
			languageEnglishButtonText.text = converter.GetMessage("test.i18n.languageEnglishButton");
		}

		public void SetLanguageToGerman()
		{
			defaultLanguage = Languages.de;
		}

		public void SetLanguageToEnglish()
		{
			defaultLanguage = Languages.en;
		}
	}
}
