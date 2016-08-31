using UnityEngine;
using System.Collections;

public class ControlButton : MonoBehaviour
{
	private const bool STICK_NONWORKING_BUTTONS = false;

	public KeyCode Key;
	private float YWhenUp;
	public float YWhenDown;
	public float YChangeRate;

	private bool working = false;

	// Use this for initialization
	void Start()
	{
		YWhenUp = transform.localPosition.y;

		if (STICK_NONWORKING_BUTTONS) {
			var activators = FindObjectsOfType<ActivateOnInput>();
			foreach(var activator in activators) {
				if (activator.KeyToActivate == Key) {
					working = true;
				}
			}
		} else {
			working = true;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		var localPos = transform.localPosition;

		if (Input.GetKey(Key)) {
			localPos.y -= YChangeRate * Time.deltaTime;
		} else {
			if (working) // don't reset if not working
				localPos.y += YChangeRate * Time.deltaTime;
		}

		localPos.y = Mathf.Clamp(localPos.y, YWhenDown, YWhenUp);

		transform.localPosition = localPos;
	}
}

