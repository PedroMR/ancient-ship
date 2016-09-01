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

	private bool mouseDownOnThis;

	// Use this for initialization
	void Start()
	{
		mouseDownOnThis = false;
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

	void OnMouseDown()
	{
		mouseDownOnThis = true;
		InputBroker.Instance.ForceKeyDown(Key);
	}

	void OnMouseUp()
	{
		mouseDownOnThis = false;
		InputBroker.Instance.ClearKeyDown(Key);
	}

	// Update is called once per frame
	void Update()
	{			
		var localPos = transform.localPosition;

		if (InputBroker.Instance.GetKey(Key)) {
			localPos.y -= YChangeRate * Time.deltaTime;
		} else {
			if (working) // don't reset if not working
				localPos.y += YChangeRate * Time.deltaTime;
		}

		localPos.y = Mathf.Clamp(localPos.y, YWhenDown, YWhenUp);

		transform.localPosition = localPos;
	}
}

