using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DialogTesterCallback : MonoBehaviour
{
	public void OnTesterCallback(string text)
	{
		Debug.Log(text);
	}
}