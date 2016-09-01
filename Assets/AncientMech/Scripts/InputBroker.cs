using UnityEngine;
using System.Collections.Generic;

public class InputBroker 
{
	private static InputBroker _instance;
	public static InputBroker Instance {
		get { return _instance ?? new InputBroker(); }
	}

	private HashSet<KeyCode> forcedKeysDown;

	public InputBroker() {
		_instance = this;
		forcedKeysDown = new HashSet<KeyCode>();
	}

	public bool GetKey(KeyCode key) {
		return Input.GetKey(key) || forcedKeysDown.Contains(key);
	}

	public void ForceKeyDown(KeyCode key) {
		forcedKeysDown.Add(key);
	}

	public void ClearKeyDown(KeyCode key) {
		if (forcedKeysDown.Contains(key))
			forcedKeysDown.Remove(key);
	}
}

