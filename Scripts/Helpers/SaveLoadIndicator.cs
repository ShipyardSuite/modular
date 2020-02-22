using UnityEngine;
using UnityEngine.UI;

namespace Shipyard.Modular.Helper
{
	public class SaveLoadIndicator : MonoBehaviour
	{
		public RectTransform[] circles;

		void Awake()
		{
			FadeOut(0.0f);
		}

		void Update()
		{
			circles[0].Rotate(0f, 0f, 100f * Time.deltaTime);
			circles[1].Rotate(0f, 0f, -200f * Time.deltaTime);
			circles[2].Rotate(0f, 0f, 300f * Time.deltaTime);
		}

		public void FadeIn(float speed = 0.5f)
		{
			foreach (RectTransform circle in circles)
			{
				circle.GetComponent<Image>().CrossFadeAlpha(1, speed, false);
			}
		}

		public void FadeOut(float speed = 0.5f)
		{
			foreach (RectTransform circle in circles)
			{
				circle.GetComponent<Image>().CrossFadeAlpha(0, speed, false);
			}
		}
	}
}
