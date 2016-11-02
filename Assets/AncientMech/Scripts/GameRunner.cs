using UnityEngine;
using System.Collections;

public class GameRunner : MonoBehaviour
{
	public static GameRunner Instance;

	public float DestructionTotal = 0;

	// Use this for initialization
	void Awake()
	{
		Instance = this;

		var config = SessionConfig.Instance;
		if (config.numPlayers == 0) {
			config.numPlayers = 1;
			config.playerControls = new SessionConfig.ControlType[] { SessionConfig.ControlType.Controller1 };
		}
	}
	
	public void LateUpdate()
	{
		InputBroker.Instance.NewFrame();
	}

	public void DestructionCaused(float amount) {
		DestructionTotal += amount;

	}
}

