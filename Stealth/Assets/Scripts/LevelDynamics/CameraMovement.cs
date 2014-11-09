using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public float smooth = 1.5f;

	private Transform player;
	private Vector3 relativeCameraPosition;
	private float relativeCameraPositionMag;
	private Vector3 newCameraPosition;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		relativeCameraPosition = transform.position - player.position;
		relativeCameraPositionMag = relativeCameraPosition.magnitude - 0.5f;
	}

	void FixedUpdate ()
	{
		Vector3 standardPosition = player.position + relativeCameraPosition;
		Vector3 abovePosition = player.position + Vector3.up * relativeCameraPositionMag;

		Vector3[] checkPoints = new Vector3[5];

		checkPoints [0] = standardPosition;
		checkPoints [1] = Vector3.Lerp (standardPosition, abovePosition, 0.25f);
		checkPoints [2] = Vector3.Lerp (standardPosition, abovePosition, 0.5f);
		checkPoints [3] = Vector3.Lerp (standardPosition, abovePosition, 0.75f);
		checkPoints [4] = abovePosition;

		for (int i=0; i<checkPoints.Length; i++) {
			if (ViewingPositionCheck (checkPoints[i])) {
				break;
			}
		}

		transform.position = Vector3.Lerp (transform.position, newCameraPosition, smooth * Time.deltaTime);
		SmoothLookAt ();
	}

	bool ViewingPositionCheck (Vector3 checkPosition)
	{
		RaycastHit hit;

		if (Physics.Raycast (checkPosition, player.position - transform.position, out hit, relativeCameraPositionMag)) {
			if (hit.transform != player) {
				return false;
			}
		}

		newCameraPosition = checkPosition;

		return true;
	}

	void SmoothLookAt ()
	{
		Vector3 relativePlayerPosition = player.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation (relativePlayerPosition, Vector3.up);
		transform.rotation = Quaternion.Lerp (transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}
}
