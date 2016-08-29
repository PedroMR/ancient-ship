using UnityEngine;
using System.Collections;

public class ActivateOnInput : MonoBehaviour {
	public Behaviour[] TargetComponents;
	public GameObject[] TargetObjects;
	public KeyCode KeyToActivate;
	public bool ActivateWhileHolding = true;

	private bool active = false;

	// Update is called once per frame
	void Update () {
		if (ActivateWhileHolding) {
			if (TargetComponents != null) {
				foreach(var component in TargetComponents)
					component.enabled = Input.GetKey(KeyToActivate);
			}
			if (TargetObjects != null) {
				foreach(var gameObject in TargetObjects)
					gameObject.SetActive(Input.GetKey(KeyToActivate));
			}
		} else {
			if (Input.GetKeyDown(KeyToActivate)) {
//					TargetComponent.enabled = !TargetComponent.enabled;
			}
		}
	}
}
