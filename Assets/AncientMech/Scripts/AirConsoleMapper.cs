using UnityEngine;
using System.Collections;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AirConsoleMapper : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onConnect += OnConnect;
	}

	void OnConnect (int device_id)
	{
		Debug.Log("OnConnect " + device_id);
		AirConsole.instance.SetActivePlayers();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void OnMessage(int from, JToken data) {
		Debug.Log("OnMessage " + from + " " + data);
//		AirConsole.instance.Message

		var key = (string)data["key"];
		var down = (bool)data["pressed"];
		var keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
		if (down)
			InputBroker.Instance.ForceKeyDown(keyCode);
		else
			InputBroker.Instance.ClearKeyDown(keyCode);
	}
}

