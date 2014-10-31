using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GUIText countText;
	public GUIText winText;

	private int count;

	void Start() {
		count = 0;
		UpdateCountText ();
		winText.text = "";
	}

	void FixedUpdate() {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive(false);
			count ++;
			UpdateCountText();

			if (count >= 12) {
				winText.text = "YOU WIN!";
			}
		}
	}

	private void UpdateCountText() {
		countText.text = "Count: " + count.ToString();
	}
}
