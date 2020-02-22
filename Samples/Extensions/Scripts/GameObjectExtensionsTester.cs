using UnityEngine;

using Shipyard.Modular.Extension;

namespace Shipyard.Modular.Test
{
	public class GameObjectExtensionsTester : MonoBehaviour
	{
		private int setLayer = 0;
		private bool setCollision = true;
		private bool showRenderer = true;

		public GameObject testCube;

		// Start is called before the first frame update
		private void Update()
		{
			testCube.SetLayerRecursively(setLayer);
			testCube.SetCollisionRecursively(setCollision);
			testCube.SetRendererRecursively(showRenderer);
		}

		public void SetLayerRecursivelyTest()
		{
			setLayer = setLayer == 0 ? 8 : 0;
		}

		public void SetCollisionRecursivelyTest()
		{
			setCollision = !setCollision;
		}

		public void SetRendererRecursivelyTest()
		{
			showRenderer = !showRenderer;
		}

		public void GetComponentsInChildrenWithTagTest()
		{
			// ???
		}

		public void GetCollisionMaskTest()
		{
			Debug.Log(testCube.GetCollisionMask());
		}

		public void IsInLayerMaskTest()
		{
			Debug.Log(testCube.IsInLayerMask(8));
		}

		public void GetInterfaceTest()
		{

		}

		public void GetInterfacesTest()
		{

		}
	}
}

