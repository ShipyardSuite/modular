using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shipyard.Demo
{
	public class Movement : MonoBehaviour
	{
		public const float stepDuration = 0.5f;
		private Coroutine playerMovement;

		private void Update()
		{
			if (playerMovement == null)
			{
				if (Input.GetKey(KeyCode.W))
					playerMovement = StartCoroutine(Move(Vector3.forward));
				else if (Input.GetKey(KeyCode.S))
					playerMovement = StartCoroutine(Move(Vector3.back));
				else if (Input.GetKey(KeyCode.D))
					playerMovement = StartCoroutine(Move(Vector3.right));
				else if (Input.GetKey(KeyCode.A))
					playerMovement = StartCoroutine(Move(Vector3.left));
			}
		}

		private IEnumerator Move(Vector3 direction)
		{
			Vector3 startPosition = transform.position;
			Vector3 destinationPosition = transform.position + direction;
			float t = 0.0f;

			while (t < 1.0f)
			{
				transform.position = Vector3.Lerp(startPosition, destinationPosition, t);
				t += Time.deltaTime / stepDuration;
				yield return new WaitForEndOfFrame();
			}

			transform.position = destinationPosition;

			playerMovement = null;
		}
	}
}
