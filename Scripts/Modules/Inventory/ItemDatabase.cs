using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shipyard.Modular.Inventory
{
	public class ItemDatabase : MonoBehaviour
	{
		public List<Item> items = new List<Item>();

		private void Awake()
		{
			BuildDatabase();
		}

		public Item GetItem(string id)
		{
			return items.Find(item => item.id == id);
		}

		// public Item GetItem(string itemName)
		// {
		// 	return items.Find(item => item.title == itemName);
		// }

		void BuildDatabase()
		{
			items = new List<Item>() {
				new Item("0", "Diamond Sword", "A sword made of diamonds.", "pick_diamond",
				new Dictionary<string, int>
				{
					{ "Power", 15 },
					{ "Defense", 10 }
				}),
				new Item("1", "Diamond Ore", "A handful of Diamond ore.", "sword_diamond",
				new Dictionary<string, int>
				{
					{ "Value", 45 }
				}),
				new Item("2", "Silver Pick", "A Silver pick axe.", "ore_diamond",
				new Dictionary<string, int>
				{
					{ "Power", 15 },
					{ "Mining", 25 }
				})
			};

		}
	}
}
