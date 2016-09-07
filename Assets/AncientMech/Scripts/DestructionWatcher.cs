using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestructionWatcher : MonoBehaviour
{
	public Text DestructionLabel;

	// Use this for initialization
	void Start()
	{
		if (DestructionLabel != null) {
			DestructionLabel.text = "NO DAMAGE";
		}
	}

	// Update is called once per frame
	void Update()
	{
		//TODO notification for this
		if (DestructionLabel != null) {
			var total = GameRunner.Instance.DestructionTotal;
			DestructionLabel.text = total == 0 ? "NO DAMAGE" : "$"+total.ToString("f1")+" MILLION";

			if (total > 0)
				DestructionLabel.color = Color.yellow;
			if (total > 10)
				DestructionLabel.color = Color.red;
		}
	}
}

