using UnityEngine;
using System.Collections;

public class YoonMovement : MonoBehaviour 
{
	public float speed = 5.0f;
	public float speedDamping = 0.5f;
	void Update () 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Moving (h, v);
	}

	void Moving (float h, float v) 
	{
		if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0) {
			Vector3 targetDirection = new Vector3 (h, 0, v).normalized * speed;
			transform.position = Vector3.Lerp (transform.position, targetDirection + transform.position, speedDamping * Time.deltaTime);
		}
	}

	void Rotating (float h, float v) 
	{

	}
}
