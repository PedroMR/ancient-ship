using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

		var newColor = Color.HSVToRGB(Random.value, Random.Range(0.8f, 1f), 1.0f);
		var renderer = GetComponent<Renderer>();
		renderer.material.color = newColor;	
	}

}

