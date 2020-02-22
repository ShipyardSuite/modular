using System;
using UnityEngine;
using System.Globalization;

using SimpleJSON;

namespace Shipyard.Modular.Internationalization
{
	public class i18n
	{
		public Languages language = Languages.de;
		public string filename = "";

		public i18n() { }

		public i18n(Languages language)
		{
			this.language = language;
		}

		public i18n(Languages language, string filename)
		{
			this.language = language;
			this.filename = filename;
		}

		public string GetMessage(string location, string value = "")
		{
			string locationString = $"i18n/";

			if (filename != "")
			{
				locationString = $"i18n/{ filename }_";
			}

			TextAsset targetFile = Resources.Load<TextAsset>(locationString + language.ToString());

			string parsedContent = "";

			if (targetFile)
			{
				var jsonString = JSON.Parse(targetFile.text);
				string[] locationArray = location.Split('.');


				if (locationArray.Length == 4)
				{
					parsedContent = jsonString[locationArray[0].ToString()][locationArray[1].ToString()][locationArray[2].ToString()][locationArray[3].ToString()].Value.Replace("{val}", value);
				}
				else if (locationArray.Length == 3)
				{
					parsedContent = jsonString[locationArray[0].ToString()][locationArray[1].ToString()][locationArray[2].ToString()].Value.Replace("{val}", value);
				}
			}

			string outputString = parsedContent != "" ? parsedContent : "[MISSING]";

			return outputString;
		}

		public string ValueToString(int input)
		{
			return convertValueToString((float)input);
		}

		public string ValueToString(float input)
		{
			return convertValueToString(input);
		}

		public float StringToValue(string input)
		{
			if (input == "")
			{
				return 0;
			}
			else
			{
				return float.Parse(input, CultureInfo.InvariantCulture.NumberFormat);
			}
		}

		public string secondsToTime(float passedTime)
		{
			float hours = passedTime / 3600;
			float minutes = (passedTime % 3600) / 60;
			float seconds = (passedTime % 3600) % 60;

			return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
		}

		public string DateTime(DateTime date)
		{
			return date.ToString("yyyy/MM/dd HH:mm:ss");
		}

		public string HoursToClock(int currentHours, int maxHours = 24)
		{
			int currentIngameTime = currentHours;
			string valueString = "";

			if (currentIngameTime <= 0)
			{
				currentIngameTime = 0;
			}
			else if (currentIngameTime >= 24)
			{
				currentIngameTime = 0;
			}

			switch (maxHours)
			{
				case 24:
				default:
					valueString = string.Format("{0:00}:00", currentIngameTime);
					break;
				case 12:
					float tempTime = currentIngameTime;

					if (currentIngameTime > 12)
					{
						tempTime -= 12;
					}

					if (currentIngameTime < 12)
					{
						valueString = string.Format("{0:00}:00 AM", tempTime);
					}
					else if (currentIngameTime >= 12)
					{
						valueString = string.Format("{0:00}:00 PM", tempTime);
					}

					break;
			}

			return valueString;
		}

		private string convertValueToString(float input)
		{
			return string.Format("{0:N}", input);
		}
	}
}