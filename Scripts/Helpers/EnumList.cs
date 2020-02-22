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
	public string value; // here will store the name of the day (string)
	[HideInInspector] public int valueIndex; // here store the index of the chosen day

	public List<string> ListOfValues = new List<string> { "Sat", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri" }; // you can add or remove days from the inspector

}
}