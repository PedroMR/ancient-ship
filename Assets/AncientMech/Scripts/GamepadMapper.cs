using UnityEngine;
using System.Collections;
using InControl;

public class GamepadMapper : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		foreach(var device in InputManager.Devices) {
			Debug.Log("Device " + device.Name + " attached? " + device.IsKnown);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		var inputDevice = InputManager.ActiveDevice;
		var input1 = inputDevice; //InputManager.Devices[0];

		if (input1 != null) {
			CheckControl(input1, InputControlType.Action1, KeyCode.Q);
			CheckControl(input1, InputControlType.Action2, KeyCode.W);
			CheckControl(input1, InputControlType.Action3, KeyCode.E);
			CheckControl(input1, InputControlType.Action4, KeyCode.A);
			CheckControl(input1, InputControlType.DPadLeft, KeyCode.S);
			CheckControl(input1, InputControlType.DPadUp, KeyCode.S);
			CheckControl(input1, InputControlType.DPadRight, KeyCode.S);
			CheckControl(input1, InputControlType.DPadDown, KeyCode.S);
			CheckControl(input1, InputControlType.LeftBumper, KeyCode.X);
			CheckControl(input1, InputControlType.LeftTrigger, KeyCode.X);
			CheckControl(input1, InputControlType.RightTrigger, KeyCode.Z);
			CheckControl(input1, InputControlType.RightBumper, KeyCode.Z);
		}
	}

	void CheckControl(InputDevice inputDevice, InputControlType control, KeyCode keyCode)
	{
		if (inputDevice.GetControl(control).WasPressed) {
			InputBroker.Instance.ForceKeyDown(keyCode);
		} else if (inputDevice.GetControl(control).WasReleased) {
			InputBroker.Instance.ClearKeyDown(keyCode);
		}
	}
}

