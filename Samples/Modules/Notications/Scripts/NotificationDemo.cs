using UnityEngine;

using Shipyard.Modular.Notifications;

namespace Shipyard.Modular.Test
{
	public class NotificationDemo : MonoBehaviour
	{
		public Sprite TestIcon;

		public void Hit()
		{
			NotificationManager.Instance.CreateNotification(TestIcon, "ABC", "DEF");
		}
	}
}
