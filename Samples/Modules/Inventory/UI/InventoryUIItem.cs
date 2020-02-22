﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Shipyard.Modular.Inventory
{
	public class InventoryUIItem : MonoBehaviour
	{
		public Item item;
		private Image spriteImage;

		private void Awake()
		{
			spriteImage = GetComponent<Image>();

			UpdateItem(null);
		}

		public void UpdateItem(Item item)
		{
			this.item = item;

			if (this.item != null)
			{
				spriteImage.color = Color.white;
				spriteImage.sprite = this.item.icon;
			}
			else
			{
				spriteImage.color = Color.clear;
			}
		}
	}
}
