using UnityEngine;
using System.Collections;

public class LandingPad : MonoBehaviour
{
	public enum Effect {
		WinLevel
	};

	public Effect effect;
	public float TimeRequired = 3;

	private float timeInTrigger;
	public bool Triggered = false;

	public delegate void Action(LandingPad caller);
	public Action WasTriggered;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void OnTriggerExit() {
		timeInTrigger = 0;
	}

	void OnTriggerStay() {
		timeInTrigger += Time.deltaTime;

		if (timeInTrigger >= TimeRequired) {
			if (WasTriggered != null)
				WasTriggered(this);
			Triggered = true;
		}
	}
}

