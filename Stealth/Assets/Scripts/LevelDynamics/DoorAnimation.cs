using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour 
{
	public bool requireKey;
	public AudioClip doorSwitchClip;
	public AudioClip doorDeniedClip;

	private GameObject player;
	private Animator anim;
	private PlayerInventory playerInventory;
	private HashIDs hash;
	private int count;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);
		anim = GetComponent<Animator> ();
		playerInventory = player.GetComponent<PlayerInventory> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
	}

	void Update ()
	{
		anim.SetBool (hash.openBool, count > 0);

		if (anim.IsInTransition (0) && !audio.isPlaying) {
			audio.clip = doorDeniedClip;
			audio.Play ();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {
			if (requireKey) {
				if (playerInventory.hasKey) {
					count++;
				} else {
					audio.clip = doorDeniedClip;
					audio.Play ();
				}
			} else {
				count++;
			}
		} else if (other.gameObject.tag == Tags.enemy) {
			if (other is CapsuleCollider) {
				count++;
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player || (other.gameObject.tag == Tags.enemy && other is CapsuleCollider)) {
			count = Mathf.Max (0, count-1);
		}
	}
}
