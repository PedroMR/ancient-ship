using UnityEngine;
using System.Collections.Generic;

public class RandomizeInputs : MonoBehaviour
{

	// Use this for initialization
	void Awake()
	{

		var inputComponents = GetComponentsInChildren<ActivateOnInput>();

		KeyCode[] keys = {
			KeyCode.A,
			KeyCode.Q,
			KeyCode.W,
			KeyCode.S,
			KeyCode.Z,
			KeyCode.X,
			KeyCode.E,
			KeyCode.D,
			KeyCode.C
		};

		var availableKeys = new List<KeyCode>(keys);

		foreach(var component in inputComponents) {
			var index = Random.Range(0, availableKeys.Count);
			component.KeyToActivate = availableKeys[index];
			availableKeys.RemoveAt(index);

			if (availableKeys.Count == 0) {
				availableKeys.AddRange(keys);
			}
		}
	
	}

}

