using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public float patrolSpeed = 2f;
	public float chaseSpeed = 5f;
	public float chaseWaitTime = 5f;
	public float patrolWaitTime = 1f;
	public Transform[] patrolWayPoints;

	private EnemySight enemySight;
	private NavMeshAgent nav;
	private Transform player;
	private PlayerHealth playerHealth;
	private LastPlayerSighting lastPlayerSighting;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;

	void Awake ()
	{
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		playerHealth = player.gameObject.GetComponent<PlayerHealth> ();
		lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<LastPlayerSighting> ();
	}

	void Update ()
	{
		if (enemySight.playerInSight && playerHealth.health > 0f) {
			Shooting ();		
		} else if (enemySight.personLastSighting != lastPlayerSighting.resetPosition && playerHealth.health > 0f) {
			Chasing ();
		} else {
			Patrolling ();
		}
	}

	void Shooting ()
	{
		nav.Stop ();
	}

	void Chasing ()
	{
		Vector3 sightingDeltaPos = enemySight.personLastSighting - transform.position;
		if (sightingDeltaPos.sqrMagnitude > 4) {
			nav.destination = enemySight.personLastSighting;
		}
		nav.speed = chaseSpeed;

		if (nav.remainingDistance < nav.stoppingDistance) {
			chaseTimer += Time.deltaTime;
			if (chaseTimer >= chaseWaitTime) {
				lastPlayerSighting.position = lastPlayerSighting.resetPosition;
				enemySight.personLastSighting = lastPlayerSighting.resetPosition;
				chaseTimer = 0f;
			}
		} else {
			chaseTimer = 0f;
		}

	}

	void Patrolling ()
	{
		nav.speed = patrolSpeed;

		if (nav.destination == lastPlayerSighting.resetPosition || nav.remainingDistance < nav.stoppingDistance) {
			patrolTimer += Time.deltaTime;

			if (patrolTimer >= patrolWaitTime) {
				wayPointIndex = (wayPointIndex+1)%patrolWayPoints.Length;
				patrolTimer = 0f;
			}
		} else {
			patrolTimer = 0f;
		}

		nav.destination = patrolWayPoints [wayPointIndex].position;
	}
}
