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

