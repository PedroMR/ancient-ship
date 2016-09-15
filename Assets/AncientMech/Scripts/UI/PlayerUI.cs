using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUI : MonoBehaviour
{
	public int PlayerNumber;
	public SessionConfig.ControlType control;

	public Text PlayerIdLabel;
	public Text ControlLabel;
	public Image Overlay;

	// Use this for initialization
	void Start()
	{
		control = SessionConfig.ControlType.None;
		SetPlayerNumber(PlayerNumber);
		SetSelected(false);
	}

	public void SetPlayerNumber(int num)
	{
		PlayerNumber = num;
		PlayerIdLabel.text = "P"+PlayerNumber;
	}

	public void SetControlType(SessionConfig.ControlType control)
	{
		this.control = control;
		ControlLabel.text = control.ToString();
		SetSelected(control != SessionConfig.ControlType.None);
	}

	public void SetSelected(bool selected)
	{
		Overlay.enabled = !selected;
	}
}

