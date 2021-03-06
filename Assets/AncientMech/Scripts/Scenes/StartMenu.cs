﻿using UnityEngine;
using UnityEngine.UI;
using InControl;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class StartMenu : MonoBehaviour
{
	public PlayerUI[] playerUIs;

	public Button StartButton;

	private SessionConfig config;

	// Use this for initialization
	void Start()
	{
		config = SessionConfig.Instance;
		config.numPlayers = 0;

		StartButton.interactable = false;
		StartButton.onClick.AddListener(StartGame);

//		foreach(var device in InputManager.Devices)
//		{
//			Debug.Log("Device " + device.Name);
//			foreach (var control in device.Controls) {
//				if (control != null) {
//					Debug.Log(control.ToString());
//					Debug.Log(control.Handle);
//				}
//			}
//		}

	}
	
	// Update is called once per frame
	void Update()
	{
		foreach(var device in InputManager.Devices)
			CheckDevice(device);

		StartButton.interactable = config.numPlayers > 0;

		if (InputManager.ActiveDevice.MenuWasPressed)
			StartGame();
	}

	void CheckDevice(InputDevice device)
	{
		//TODO check disconnections
		if (device.AnyButton || device.MenuWasPressed) {
			var control = GetControlTypeFor(device);

			var alreadyThere = false;
			foreach(var player in playerUIs) {
				if (player.control == control) {
					alreadyThere = true;
					break;
				}
			}

			if (!alreadyThere) {
				AddControl(control);
			}
		}
	}

	SessionConfig.ControlType GetControlTypeFor(InputDevice device)
	{
		for (var i=0; i < InputManager.Devices.Count; i++) {
			if (InputManager.Devices[i] == device) {
				return (SessionConfig.ControlType)i;
			}
		}

		return SessionConfig.ControlType.Keyboard1;
	}

	void AddControl(SessionConfig.ControlType control)
	{
		var playerId = config.numPlayers;
		config.numPlayers++;
		playerUIs[playerId].SetPlayerNumber(config.numPlayers);
		playerUIs[playerId].SetControlType(control);
	}

	public void StartGame()
	{
		if (config.numPlayers <= 0)
			return;
		
		config.playerControls = new SessionConfig.ControlType[config.numPlayers];
		for (var i=0; i < config.numPlayers; i++) {
			config.playerControls[i] = playerUIs[i].control;
		}
		SceneManager.LoadScene("3D");
	}

	public void ResetControls()
	{
		config.numPlayers = 0;
		foreach (var player in playerUIs) {
			player.SetControlType(SessionConfig.ControlType.None);
		}
	}
}

