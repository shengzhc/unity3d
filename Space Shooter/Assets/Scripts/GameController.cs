using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameoverText;

	private int score;
	private bool restart;
	private bool isGameOver;

	// Use this for initialization
	void Start () {

		gameoverText.text = "";
		restartText.text = "";

		isGameOver = false;
		restart = false;

		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves () {

		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i=0; i<hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (isGameOver) {
				restart = true;
				restartText.text = "Press 'R' to Restart.";
				break;
			}
		}
	}

	void Update () {

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public void AddScore (int scoreValue) {
		score += scoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	public void GameOver () {
		gameoverText.text = "Game Over!";
		isGameOver = true;
	}
}
