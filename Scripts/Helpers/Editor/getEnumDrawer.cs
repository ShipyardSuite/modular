
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Shipyard.Modular.Helper{
[CustomPropertyDrawer(typeof(getValues))]
public class getStringEnumDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		getValues att = attribute as getValues;
		string propertyPath = property.propertyPath;
		string dayIndex = propertyPath.Replace(property.name, att.valueIndex);
		SerializedProperty sourceProperty = property.serializedObject.FindProperty(dayIndex);

		EnumList myscript = (property.serializedObject.targetObject) as EnumList;

		if (myscript.ListOfValues == null)
			return;

		List<string> values = new List<string> { "None" };
		for (int x = 0; x < myscript.ListOfValues.Count; x++)
		{
			values.Add(x + "-" + myscript.ListOfValues[x]);
		}

		EditorGUI.PrefixLabel(position, new GUIContent("Value: "));
		position.x += Screen.width / 4;
		position.width -= Screen.width / 4;

		sourceProperty.intValue = Mathf.Clamp(sourceProperty.intValue, 0, values.Count - 1);
		sourceProperty.intValue = EditorGUI.Popup(position, sourceProperty.intValue, values.ToArray());

		property.stringValue = sourceProperty.intValue > 0 ? myscript.ListOfValues[sourceProperty.intValue - 1] : "";
	}
}
}