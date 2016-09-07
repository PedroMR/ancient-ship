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
	}
	
	public void DestructionCaused(float amount) {
		DestructionTotal += amount;

	}
}

