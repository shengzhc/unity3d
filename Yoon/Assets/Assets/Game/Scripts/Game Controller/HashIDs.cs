using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour 
{
	public int playerIdle0Trigger;
	public int playerIdle1Trgger;
	public int playerSpeedFloat;

	void Awake ()
	{
		playerIdle0Trigger = Animator.StringToHash ("Idle0");
		playerIdle1Trgger = Animator.StringToHash ("Idle1");
		playerSpeedFloat = Animator.StringToHash ("Speed");
	}
}
