using UnityEngine;
using System.Collections;

public class YoonMovement : MonoBehaviour 
{
	public float speed = 5.0f;
	public float speedSmoothing = 0.5f;
	public float turningSmoothing = 5.0f;

	private YoonAnimationController animator;

	void Awake ()
	{
		animator = GetComponent<YoonAnimationController> ();
	}

	void Update () 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Moving (h, v);
		Rotating (h, v);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Jumping ();
		}
	}

	void Moving (float h, float v) 
	{
		if (h != 0 || v != 0) {
			Vector3 target = new Vector3 (h, transform.position.y, v).normalized * speed + transform.position;
			transform.position = Vector3.Lerp (transform.position, target, speedSmoothing * Time.deltaTime);
			animator.Walk ();
		} else {
			animator.Idle ();
		}
	}

	void Rotating (float h, float v) 
	{
		if (h != 0 || v != 0) {
			Quaternion targetRotation = Quaternion.LookRotation (new Vector3 (h, transform.position.y, v), Vector3.up);
			Quaternion newRotation = Quaternion.Lerp (transform.rotation, targetRotation, turningSmoothing * Time.deltaTime);
			transform.rotation = newRotation;
		}
	}

	void Jumping () 
	{
		animator.Jump ();
	}
}
