using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 1.0f;
	public float angularSpeed = 5.0f;

	private Animator anim;
	private HashIDs hash;
	
	void Awake ()
	{
		anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tag.gameController).GetComponent<HashIDs> ();
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Moving (horizontal, vertical);
		Rotating (horizontal, vertical);
	}

	void Moving (float h, float v) 
	{
		if (h != 0 || v != 0) 
		{
			Vector3 direction = new Vector3 (h, 0, v);
			Vector3 targetPosition = transform.position + direction * speed * Time.deltaTime;
			rigidbody.MovePosition (targetPosition);
		}
	}

	void Rotating (float h, float v)
	{
		if (h != 0 || v != 0) {
			Quaternion targetDirection = Quaternion.LookRotation (new Vector3 (h, 0, v), Vector3.up);
			Quaternion newRotation = Quaternion.Lerp (transform.rotation, targetDirection, angularSpeed * Time.deltaTime);
			rigidbody.MoveRotation (newRotation);
		}
	}
}
