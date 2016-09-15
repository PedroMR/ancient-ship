using UnityEngine;
using System.Collections;
using InControl;

public class GamepadMapper : MonoBehaviour
{
	public KeyCode[][] keysByPlayer;

	// Use this for initialization
	void Start()
	{
		var config = SessionConfig.Instance;
		var allKeys = RandomizeInputs.allKeys;
		var keysForEach = Mathf.CeilToInt(allKeys.Length / (float)config.numPlayers);

		Debug.Log("each of the " + config.numPlayers + " players gets " + keysForEach + " keys");

		keysByPlayer = new KeyCode[config.numPlayers][];
		int k=0;
		for (int i = 0; i < config.numPlayers; i++) {
			keysByPlayer[i] = new KeyCode[keysForEach];

			for (int j=0; j < keysForEach && k < allKeys.Length; j++, k++) {
				keysByPlayer[i][j] = allKeys[k];
			}
		}

//		for (int i = 0; i < keysByPlayer.Length; i++) {
//			var str = "Player " + i + ": ";
//			for (int j = 0; j < keysByPlayer[i].Length; j++) {
//				str += keysByPlayer[i][j].ToString() + ",";
//			}
//			Debug.Log(str);
//		}


//		foreach(var device in InputManager.Devices) {
//			Debug.Log("Device " + device.Name + " attached? " + device.IsKnown);
//		}
	}

	static InputControlType[] buttonOrder = new InputControlType[] {
		InputControlType.Action1,
		InputControlType.Action2,
		InputControlType.Action3,
		InputControlType.Action4,
		InputControlType.DPadLeft,
		InputControlType.LeftBumper,
		InputControlType.RightBumper,
		InputControlType.LeftTrigger,
		InputControlType.RightTrigger
	};

	void Update()
	{
		var config = SessionConfig.Instance;

		for (var playerId = 0; playerId < config.numPlayers; playerId++) {
			var control = config.playerControls[playerId];
			var device = GetInputDeviceForControl(control);

			if (device == null)
				continue;

			var playerKeys = keysByPlayer[playerId];

			for (var keyIndex = 0; keyIndex < playerKeys.Length; keyIndex++) {
				CheckControl(device, buttonOrder[keyIndex], playerKeys[keyIndex]);
				if (buttonOrder[keyIndex] == InputControlType.DPadLeft) {
					CheckControl(device, InputControlType.DPadUp, playerKeys[keyIndex]);
					CheckControl(device, InputControlType.DPadDown, playerKeys[keyIndex]);
					CheckControl(device, InputControlType.DPadRight, playerKeys[keyIndex]);
				}
			}

		}

/*
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
	*/
	}

	InputDevice GetInputDeviceForControl(SessionConfig.ControlType control) {
		InputDevice device = null;

		int deviceId = (int)control;
		if (deviceId >= 0 && deviceId < InputManager.Devices.Count)
			device = InputManager.Devices[deviceId];

		return device;
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

