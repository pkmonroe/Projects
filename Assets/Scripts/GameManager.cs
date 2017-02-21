using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject debrisPrefab;

	public CameraController playerCamera;

	private PlayerController playerController;

	public GameObject[] respawns;

	private short playerScore = 0;

	void Start () {

		respawns = GameObject.FindGameObjectsWithTag("Spawn");
		
		//Create the Player.
		GameObject player = Instantiate(playerPrefab, new Vector3(0, 10, 0), Quaternion.identity);
		playerController = player.GetComponentInChildren<PlayerController> ();
		playerController.SetGameManager (this);

		playerCamera.playerGameObject = playerController.playerWatcher;

		for (int i = 0; i < respawns.Length; i++) {
			Vector3 pos = respawns [i].transform.position;
			pos.y = 1;
			Instantiate(debrisPrefab, pos, Quaternion.identity);
		}

		UpdateScoreLabel ();


	}

	public void CollectDebris() {
		playerScore++;
		UpdateScoreLabel ();
		if (playerScore == respawns.Length) {
			Debug.LogWarning ("GAME OVER");		
		}
	}

	private void UpdateScoreLabel() {
		UIManager.Instance.ScoreLabel.SetText(string.Format("{0}/{1} Mushrooms Collected", playerScore, respawns.Length));
	}
		

}
