using UnityEngine;
using System.Collections;

public class MouseCameraControl : MonoBehaviour
{
	public Transform target;
	public float MaxZ = 100.0f;
	public float MinZ = 10.0f;
	public float ZChangePerWheel = 1f;

	public float zOffset = 20.0f;


	private void LateUpdate()
	{
		if (target == null || !target.gameObject.activeInHierarchy) {
			var shipCenters = GameObject.FindGameObjectsWithTag("Player");
			foreach (var ship in shipCenters) {
				if (ship.activeInHierarchy) {
					target = ship.transform;
				}
			}
		}

		zOffset += Input.mouseScrollDelta.y * ZChangePerWheel * Time.deltaTime;
			
		zOffset = Mathf.Clamp(zOffset, MinZ, MaxZ);

		transform.position = target.position + Vector3.back * zOffset;
	}
}

