using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour 
{
	public AudioClip keyPickupClip;

	private GameObject player;
	private PlayerInventory playerInventory;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);
		playerInventory = player.GetComponent<PlayerInventory> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {
			AudioSource.PlayClipAtPoint (keyPickupClip, transform.position);
			playerInventory.hasKey = true;
			Destroy (gameObject);
		}
	}
}
