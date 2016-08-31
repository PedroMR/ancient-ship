using UnityEngine;
using System.Collections;

public class PartJoiner : MonoBehaviour
{
	void Start()
	{
		var objectsNearby = Physics.OverlapSphere(transform.position, 1);
		foreach(var obj in objectsNearby) {
			if (obj.CompareTag("Ship Part")) {
				var joint = gameObject.AddComponent<FixedJoint>();
				joint.connectedBody = obj.GetComponent<Rigidbody>();
			}
		}
	}

}

