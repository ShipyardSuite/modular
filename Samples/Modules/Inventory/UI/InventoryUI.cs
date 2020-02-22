using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shipyard.Modular.Inventory
{
	public class InventoryUI : MonoBehaviour
	{
		public List<InventoryUIItem> uIItems = new List<InventoryUIItem>();

		public GameObject slotPrefab;
		public Transform slotPanel;

		public int numberOfSlots = 16;

		private void Awake()
		{
			for (int i = 0; i < numberOfSlots; i++)
			{
				GameObject instance = Instantiate(slotPrefab);

				instance.transform.SetParent(slotPanel);

				uIItems.Add(instance.GetComponentInChildren<InventoryUIItem>());
			}
		}

		public void UpdateSlot(int slot, Item item)
		{
			uIItems[slot].UpdateItem(item);
		}

		public void AddNewItem(Item item)
		{
			UpdateSlot(uIItems.FindIndex(i => i.item == null), item); ;
		}

		public void RemoveItem(Item item)
		{
			UpdateSlot(uIItems.FindIndex(i => i.item == item), null); ;
		}
	}
}
