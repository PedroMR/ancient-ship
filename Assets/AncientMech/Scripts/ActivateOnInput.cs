using UnityEngine;
using System.Collections;

public class ActivateOnInput : MonoBehaviour {
	public Behaviour[] TargetComponents;
	public GameObject[] TargetObjects;
	public KeyCode KeyToActivate;
	public bool ActivateWhileHolding = true;

	public bool CurrentlyActive = false;

	// Update is called once per frame
	void Update () {
		var previousStatus = CurrentlyActive;
		if (ActivateWhileHolding) {
			CurrentlyActive = InputBroker.Instance.GetKey(KeyToActivate);
		} else {
			if(InputBroker.Instance.GetKeyDown(KeyToActivate)) {
				CurrentlyActive = !CurrentlyActive;
			}
		}

		if (CurrentlyActive != previousStatus)
			RefreshObjects();
	}

	void RefreshObjects()
	{
		if (TargetComponents != null) {
			foreach(var component in TargetComponents)
				component.enabled = CurrentlyActive;
		}
		if (TargetObjects != null) {
			foreach(var gameObject in TargetObjects)
				gameObject.SetActive(CurrentlyActive);
		}		
	}
}
