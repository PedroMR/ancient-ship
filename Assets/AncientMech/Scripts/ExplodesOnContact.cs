﻿using UnityEngine;
using System.Collections;

public class ExplodesOnContact : MonoBehaviour
{
	public GameObject Explosion;
	public float PointValue = 1;
	public float DestructionTimer = 0.3f;

	private bool dead = false;

	// Use this for initialization
	void Start()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (dead)
			return;

		if (other.gameObject.layer != LayerMask.NameToLayer("Player") && other.gameObject.layer != LayerMask.NameToLayer("Grabbable"))
			return;
		
		if (Explosion != null) {
			var newExplosion = Instantiate(Explosion, transform.position, transform.rotation);

		}
		dead = true;
		GameRunner.Instance.DestructionCaused(PointValue + Random.value*PointValue);
		Destroy(gameObject, DestructionTimer);
	}
}

