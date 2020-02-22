using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game/Dialog")]
public class Dialog : ScriptableObject
{
	public static event Action<int> callbackRecieveXP;
	public static event Action<GameObject[]> callbackRecieveItems;

	public string id;

	public int recieveXP;
	public GameObject[] revieceItems;

	[SerializeField]
	public UnityEvent onCallback = new UnityEvent();

	public DialogSentence[] sentences;

	public Dialog(string id, DialogSentence sentence)
	{
		this.id = id;
		this.sentences[0] = sentence;
	}

	public void DialogCallback()
	{
		onCallback.Invoke();
		callbackRecieveXP(recieveXP);
		callbackRecieveItems(revieceItems);
	}
}
