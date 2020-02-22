using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shipyard.Modular.Notifications
{
	public class NotificationMessage : MonoBehaviour
	{
		public float waitTime = 5.0f;
		public bool isAutoDestructed = true;
		//public Image messageIcon;
		public Text messageHeader;
		public Text messageText;
		public Animator animator;

		void Awake()
		{
			animator = GetComponent<Animator>();
		}

		public void InitializeMessage(string messageHeaderInput, string messageTextInput)
		{
			messageHeader.text = messageHeaderInput;
			messageText.text = messageTextInput;

			ShowNotification();

			if (isAutoDestructed)
			{
				StartCoroutine(WaitForDestruction());
			}
		}

		private IEnumerator WaitForDestruction()
		{
			yield return new WaitForSeconds(waitTime);
			HideNotification();
		}


		public void ShowNotification()
		{
			animator.Play("FadeIn");
		}

		public void HideNotification()
		{
			animator.Play("FadeOut");

			DestroyMessage();
		}

		public void DestroyMessage()
		{
			Destroy(this.gameObject, 2f);
		}
	}
}