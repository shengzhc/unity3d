using UnityEngine;
using System.Collections;

public class DestryByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}
