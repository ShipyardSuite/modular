using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DialogTester : MonoBehaviour
{
	public Dialog dialog;

	public int xp = 0;
	public List<GameObject> items = new List<GameObject>();

	void OnEnable()
	{
		Dialog.callbackRecieveXP += addXP;
		Dialog.callbackRecieveItems += addIems;
	}


	void OnDisable()
	{
		Dialog.callbackRecieveXP -= addXP;
		Dialog.callbackRecieveItems += addIems;
	}

	void addXP(int amount)
	{
		xp += amount;
	}

	void addIems(GameObject[] newItems)
	{
		foreach (GameObject item in newItems)
		{
			items.Add(item);
		}
	}

	public void TriggerDialog()
	{
		FindObjectOfType<DialogManager>().StartDialog(dialog);
	}
}