using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class StartMenu : MonoBehaviour
{
	public PlayerUI[] playerUIs;

	private SessionConfig config;

	// Use this for initialization
	void Start()
	{
		config = SessionConfig.Instance;
		config.numPlayers = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		foreach(var device in InputManager.Devices)
			CheckDevice(device);
	}

	void CheckDevice(InputDevice device)
	{
		//TODO check disconnections
		if (device.AnyButton) {
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

