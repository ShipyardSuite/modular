using System.Collections.Generic;
using UnityEngine;

namespace Shipyard.Modular.Helper {
	public class getValues : PropertyAttribute
	{
		public string valueIndex;
		public getValues(string valueIndex)
		{
			this.valueIndex = valueIndex;
		}
	}

	public class EnumList : MonoBehaviour
	{
		[getValues("valueIndex")]
		public string value;
		[HideInInspector] public int valueIndex;

		public List<string> ListOfValues = new List<string> { "Sat", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri" };
	}
}