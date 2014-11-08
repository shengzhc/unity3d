using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public AudioClip shoutingClip;
	public float turningSmoothing = 15f;
	public float speedDampTime = 0.1f;

	private Animator anim;
	private HashIDs hash;

	void Awake ()
	{
		anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		anim.SetLayerWeight (1, 1.0f);
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		bool sneaking = Input.GetButton ("Sneak");

		MovementManagement (horizontal, vertical, sneaking);
	}

	void Update ()
	{
		bool shouting = Input.GetButton ("Attract");
		anim.SetBool (hash.shoutingBool, shouting);
		AudioManagement (shouting);
	}

	void MovementManagement (float horizontal, float vertical, bool sneaking)
	{
		anim.SetBool (hash.sneakingBool, sneaking);

		if (horizontal != 0 || vertical != 0) {
			Vector3 targetDirection = new Vector3 (horizontal, 0f, vertical);
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
			Quaternion newRotation = Quaternion.Lerp (transform.rotation, targetRotation, turningSmoothing * Time.deltaTime);
			rigidbody.MoveRotation (newRotation);
			anim.SetFloat (hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
		} else {
			anim.SetFloat (hash.speedFloat, 0f, speedDampTime, Time.deltaTime);
		}
	}

	void AudioManagement (bool shouting)
	{
		if (anim.GetCurrentAnimatorStateInfo (0).nameHash == hash.locomotionState) {
			if (!audio.isPlaying) {
				audio.Play ();
			}
		} else {
			audio.Stop ();
		}

		if (shouting) {
			AudioSource.PlayClipAtPoint (shoutingClip, transform.position);
		}
	}
}
