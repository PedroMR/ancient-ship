using UnityEngine;
using System.Collections.Generic;
using System;

public class InputBroker 
{
	private static InputBroker _instance;
	public static InputBroker Instance {
		get { return _instance ?? new InputBroker(); }
	}

	private HashSet<KeyCode> forcedKeysDown;
	private HashSet<KeyCode> forcedKeysDownThisFrame;

	public InputBroker() {
		_instance = this;
		forcedKeysDown = new HashSet<KeyCode>();
		forcedKeysDownThisFrame = new HashSet<KeyCode>();
	}

	public void NewFrame() {
		forcedKeysDownThisFrame.Clear();
	}
	
	public bool GetKey(KeyCode key) {
		return Input.GetKey(key) || forcedKeysDown.Contains(key);
	}

	public void ForceKeyDown(KeyCode key) {
		forcedKeysDown.Add(key);
		forcedKeysDownThisFrame.Add(key);
	}

    internal bool GetKeyDown(KeyCode key)
    {
		return Input.GetKeyDown(key) || forcedKeysDownThisFrame.Contains(key);
    }

    public void ClearKeyDown(KeyCode key) {
		if (forcedKeysDown.Contains(key))
			forcedKeysDown.Remove(key);
	}
}

