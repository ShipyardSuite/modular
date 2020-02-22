using UnityEngine;

using Shipyard.Modular.Helper;

public class DrawErrorTest : MonoBehaviour
{
	void Update()
	{
		DrawArrow.ForDebug(transform.position, transform.forward, Color.green);
	}
}
