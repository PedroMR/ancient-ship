using UnityEngine;
using System.Collections;

public class ActivateOnInput : MonoBehaviour {
	public Behaviour[] TargetComponents;
	public GameObject[] TargetObjects;
	public ParticleSystem[] TargetEmitters;
	public KeyCode KeyToActivate;
	public bool ActivateWhileHolding = true;

	public bool CurrentlyActive = false;

	void Start() {
		RefreshObjects();
	}

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
		if (TargetEmitters != null) {
			foreach(var particleSystem in TargetEmitters) {
				var em = particleSystem.emission; 
				em.enabled = CurrentlyActive;
			}
		}		
	}
}
