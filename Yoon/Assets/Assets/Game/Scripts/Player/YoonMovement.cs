using UnityEngine;
using System.Collections;

public class YoonMovement : MonoBehaviour 
{
	public float speed = 5.0f;
	public float speedSmoothing = 0.5f;
	void Update () 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Moving (h, v);
	}

	void Moving (float h, float v) 
	{
		if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0) {
			Vector3 target = new Vector3 (h, 0, v).normalized * speed + transform.position;
			transform.position = Vector3.Lerp (transform.position, target, speedSmoothing * Time.deltaTime);
		}
	}

	void Rotating (float h, float v) 
	{
		if (Mathf.Abs (h) > 0 || Mathf.Abs (v) > 0) {
			Vector3 lookAtDirection = new Vector3 (h, 0, v).normalized;

		}
	}
}
