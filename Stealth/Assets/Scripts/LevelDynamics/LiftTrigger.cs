﻿using UnityEngine;
using System.Collections;

public class LiftTrigger : MonoBehaviour 
{
	public float timeToDoorClose = 2f;
	public float timeToLiftStart = 3f;
	public float timeToEndLevel = 6f;
	public float liftSpeed = 3f;

	private GameObject player;
	private Animator playerAnim;
	public HashIDs hash;
	private CameraMovement cameraMovement;
	private SceneFadeInOut sceneFadeInOut;
	private LiftDoorTracking liftDoorTracking;
	private bool playerInLift;
	private float timer;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);
		playerAnim = player.GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		cameraMovement = Camera.main.GetComponent<CameraMovement> ();
		sceneFadeInOut = GameObject.FindGameObjectWithTag (Tags.fader).GetComponent<SceneFadeInOut> ();
		liftDoorTracking = GetComponent<LiftDoorTracking> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {
			playerInLift = true;
		}
	}

	void OnTriggerExit (Collider other) 
	{
		if (other.gameObject == player) {
			playerInLift = false;
			timer = 0.0f;
		}
	}

	void Update ()
	{
		if (playerInLift) {
			LiftActivation ();
		}

		if (timer < timeToDoorClose) {
			liftDoorTracking.DoorFollowing ();
		} else {
			liftDoorTracking.CloseDoors ();
		}
	}

	void LiftActivation ()
	{
		timer += Time.deltaTime;

		if (timer >= timeToLiftStart)
		{
			playerAnim.SetFloat (hash.speedFloat, 0.0f);
			cameraMovement.enabled = false;
			player.transform.parent = transform;

			transform.Translate (Vector3.up * liftSpeed * Time.deltaTime);

			if (!audio.isPlaying) {
				audio.Play ();
			}
		}

		if (timer >= timeToEndLevel) {
			sceneFadeInOut.EndScene ();
		}
	}
}
