using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Shipyard.Modular.Internationalization;

namespace Shipyard.Modular.UI
{
	public class LoadingScreen : MonoBehaviour
	{
		private i18n converter = new i18n();

		public Languages language;

		public RawImage backgroundImage;
		public TMP_Text descriptionText;
		public TMP_Text headerText;
		public Image gameLogo;

		public Animator animator;

		public int currentTip = 0;

		void Awake()
		{
			animator = GetComponent<Animator>();
		}

		// Start is called before the first frame update
		void Start()
		{
			IdleOff();
		}

		// Update is called once per frame
		void Update()
		{
			converter.language = language;
		}

		public void Populate(int tipnumber)
		{
			currentTip = tipnumber;

			descriptionText.text = converter.GetMessage($"game.loadingScreens.message{tipnumber}.description");
			headerText.text = converter.GetMessage($"game.loadingScreens.message{tipnumber}.header");
		}

		public void FadeIn()
		{
			gameObject.SetActive(true);
			animator.Play("FadeIn");
		}

		public void FadeOut()
		{
			animator.Play("FadeOut");
		}

		public void IdleOn()
		{
			gameObject.SetActive(true);
			animator.Play("IdleOn");
		}

		public void IdleOff()
		{
			animator.Play("IdleOff");
			gameObject.SetActive(false);
		}
	}
}
