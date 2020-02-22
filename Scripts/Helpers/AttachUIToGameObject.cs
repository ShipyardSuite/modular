using UnityEngine;
using UnityEngine.UI;

namespace Shipyard.Modular.Helper
{
	[ExecuteInEditMode]
	public class AttachUIToGameObject : MonoBehaviour
	{
		public Image crosshair;
		public Transform target;

		// Update is called once per frame
		void LateUpdate()
		{
			crosshair.transform.position = Shipyard.Modular.Extension.VectorExtensions.TransformToScreenPosition(target.position);
		}
	}
}
