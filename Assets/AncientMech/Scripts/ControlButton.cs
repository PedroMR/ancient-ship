using UnityEngine;
using System.Collections;

public class ControlButton : MonoBehaviour
{
	public KeyCode Key;
	private float YWhenUp;
	public float YWhenDown;
	public float YChangeRate;


	// Use this for initialization
	void Start()
	{
		YWhenUp = transform.localPosition.y;

		var newColor = Color.HSVToRGB(Random.value, Random.Range(0.5f, 1f), 1.0f);
//		Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		var renderer = GetComponent<Renderer>();
		renderer.material.color = newColor;	
	}
	
	// Update is called once per frame
	void Update()
	{
		var localPos = transform.localPosition;

		if (Input.GetKey(Key)) {
			localPos.y -= YChangeRate * Time.deltaTime;
		} else {
			localPos.y += YChangeRate * Time.deltaTime;
		}

		localPos.y = Mathf.Clamp(localPos.y, YWhenDown, YWhenUp);

		transform.localPosition = localPos;
	}
}

