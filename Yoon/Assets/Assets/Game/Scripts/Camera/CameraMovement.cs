using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public float rotateSpeed = 60.0f;

	void Update ()
	{
		transform.Rotate (transform.up, rotateSpeed * Time.deltaTime);
	}
}
