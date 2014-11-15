using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	private GameObject player;
	private Vector3 offset;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tag.player);
		offset = player.transform.position - transform.position;

		Debug.Log (offset);
	}

	void Update ()
	{
		transform.position = player.transform.position - offset;
	}
}
