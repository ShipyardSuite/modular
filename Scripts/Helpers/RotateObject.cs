using UnityEngine;

namespace Shipyard.Modular.Helper
{
	public class RotateObject : MonoBehaviour
	{
		public float rotateX;
		public float rotateY;
		public float rotateZ;

		public bool active = false;

		// Update is called once per frame
		void Update()
		{
			if (active)
			{
				Rotate(rotateX, rotateY, rotateZ);
			}
		}

		public void Stop()
		{
			active = false;
		}

		public void Resume()
		{
			active = true;
		}

		public void Rotate(float rotX, float rotY, float rotZ)
		{
			gameObject.transform.Rotate(rotX * Time.deltaTime, rotY * Time.deltaTime, rotZ * Time.deltaTime, Space.Self);
		}
	}
}
