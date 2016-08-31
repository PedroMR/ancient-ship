using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LandingPad : MonoBehaviour
{
	public enum Effect {
		WinLevel
	};

	public Effect effect;
	public float TimeRequired = 3;
	public Text TimeLeftLabel;

	private float timeInTrigger;
	public bool Triggered = false;

	public delegate void Action(LandingPad caller);
	public Action WasTriggered;

	void Start()
	{
		SetTimeLeft(TimeRequired);
	}

	void SetTimeLeft(float timeLeft) {
		timeLeft = Mathf.Max(0, timeLeft);

		if (TimeLeftLabel != null) {
			TimeLeftLabel.text = "T -" + timeLeft.ToString("F");
		}
	}


	void OnTriggerExit() {
		timeInTrigger = 0;
	}

	void OnTriggerStay() {
		timeInTrigger += Time.deltaTime;
		float timeLeft = TimeRequired - timeInTrigger;
		SetTimeLeft(timeLeft);

		if (timeLeft <= 0) {
			if (WasTriggered != null)
				WasTriggered(this);
			Triggered = true;
		}
	}
}

