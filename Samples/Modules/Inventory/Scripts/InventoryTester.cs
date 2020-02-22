using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shipyard.Modular.Inventory;

namespace Shipyard.Modular.Test
{
	public class InventoryTester : MonoBehaviour
	{
		public List<Item> inventoryItems = new List<Item>();
		public ItemDatabase itemDatabase;

		public InventoryUI inventoryUI;

		public void Start()
		{
			//AddItem("Diamond Sword");
			AddItem("0");
			AddItem("1");
			AddItem("2");
			//RemoveItem(1);
		}

		public void AddItem(string id)
		{
			Item itemToAdd = itemDatabase.GetItem(id);
			inventoryItems.Add(itemToAdd);
			inventoryUI.AddNewItem(itemToAdd);
			Debug.Log($"Added item: {itemToAdd.title}");
		}

		// public void AddItem(string id, string itemName)
		// {
		// 	Item itemToAdd = itemDatabase.GetItem(itemName);
		// 	inventoryItems.Add(itemToAdd);

		// 	Debug.Log($"Added item: {itemToAdd.title}");
		// }

		public Item FindItem(string id)
		{
			return inventoryItems.Find(item => item.id == id);
		}

		public void RemoveItem(string id)
		{
			Item itemToRemove = FindItem(id);

			if (itemToRemove != null)
			{
				inventoryItems.Remove(itemToRemove);
				inventoryUI.RemoveItem(itemToRemove);
				Debug.Log($"Removed item: {itemToRemove.title}");
			}
		}
	}
}
