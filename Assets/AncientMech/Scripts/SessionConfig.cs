using UnityEngine;
using System.Collections;

public class SessionConfig
{
	private static SessionConfig _instance;

	public static SessionConfig Instance {
		get {
			if (_instance == null)
				_instance = new SessionConfig();
			return _instance;
		}
	}

	public int numPlayers = 0;
	public string shipId = "Ship 4";

	public enum ControlType {
		None = -1,
		Controller1 = 0,
		Controller2,
		Controller3,
		Controller4,
		Keyboard1,
		Keyboard2,
		Mouse
	};

	public ControlType[] playerControls;
}

