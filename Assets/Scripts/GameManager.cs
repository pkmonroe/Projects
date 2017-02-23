using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	/** Editor Settings **/
	public GameObject playerPrefab;
	public GameObject positivePrefab;
	public GameObject negativePrefab;
	public CameraController playerCamera;

	/** Singleton **/
	public static GameManager _instance;

	public static GameManager Instance { get { return _instance; } }

	/** Manager member variables **/
	private short playerHealth;
	private short debrisCollected;
	private float elapsedTime;
	private float timeSinceLastSpawn = 0;

	private PlayerController playerController;

	private GameObject[] spawnPoints;
	private int nextSpawnPoint;

	private List<GameObject> spawnedDebris;

	/** Game Enabled **/
	private bool gameEnabled = false;

	void Awake() {
		_instance = this;
	}

	void Start() {
		spawnPoints = GameObject.FindGameObjectsWithTag(GameConstants.SPAWN_TAG);
		spawnPoints.Shuffle();
	}

	public void StartGame() {
		playerHealth = GameConstants.PLAYER_STARTING_HEALTH;
		debrisCollected = 0;
		elapsedTime = 0;

		if (playerController != null) {
			DestroyImmediate(playerController.gameObject);
		}

		if (spawnedDebris != null && spawnedDebris.Count > 0) {
			for (int i = spawnedDebris.Count - 1; i >= 0; i--) {
				GameObject oldDebris = spawnedDebris [i];
				spawnedDebris.RemoveAt(i);
				DestroyImmediate(oldDebris);
			}
		}

		spawnedDebris = new List<GameObject> ();

		//Create the Player.
		GameObject player = Instantiate(playerPrefab, new Vector3 (0, 10, 0), Quaternion.identity);
		playerController = player.GetComponentInChildren<PlayerController>();

		playerCamera.TargetPlayerObject(playerController.playerWatcher);

		for (int i = 0; i < GameConstants.INITIAL_DEBRIS_SPAWNS; i++) {
			SpawnDebris();
		}

		UpdateScoreLabel();
		UIManager.Instance.MainMenu.SetActive(false);
		gameEnabled = true;
	}

	void Update() {
		if (gameEnabled) {
			elapsedTime += Time.deltaTime;
			timeSinceLastSpawn += Time.deltaTime;
			if (timeSinceLastSpawn > GameConstants.DEBRIS_RESPAWN_TIME) {
				SpawnDebris();
				timeSinceLastSpawn = 0;
			}
			UpdateScoreLabel();
		}
	}

	private void SpawnDebris() {

		Vector3 pos = spawnPoints [nextSpawnPoint].transform.position;
		GameObject debrisPrefab = (nextSpawnPoint % 2 == 0) ? positivePrefab : negativePrefab;
		GameObject debris = Instantiate(debrisPrefab, pos, Quaternion.identity);
		spawnedDebris.Add(debris);

		nextSpawnPoint++;
		if (nextSpawnPoint == spawnPoints.Length) {
			nextSpawnPoint = 0;
		}
	}

	public void DestroyDebris(GameObject debris) {
		int oldDebrisIndex = spawnedDebris.IndexOf(debris);
		GameObject oldDebris = spawnedDebris [oldDebrisIndex];
		spawnedDebris.RemoveAt(oldDebrisIndex);
		DestroyImmediate(oldDebris);
	}

	public void DecrementPlayerHealth(short increment) {
		playerHealth -= increment;
		if (playerHealth <= 0) {
			gameEnabled = false;	
			UIManager.Instance.HealthLabel.SetText(string.Format("GAME OVER"));
			UIManager.Instance.MainMenu.SetActive(true);
		}
	}

	public void IncrementPlayerHealth(short increment) {
		playerHealth += increment;
	}

	public void IncrementDebrisCollected() {
		debrisCollected++;
	}

	private void UpdateScoreLabel() {
		UIManager.Instance.HealthLabel.SetText(string.Format("Player Health: {0}", playerHealth));
		UIManager.Instance.ElapsedLabel.SetText(string.Format("Elapsed Time: {0}", elapsedTime.ToString("F2")));
		UIManager.Instance.CollectedLabel.SetText(string.Format("Mushrooms Collected: {0}", debrisCollected));


	}

}

static class ExtensionMethods {
	/** Extension Methods **/
	private static System.Random rng = new System.Random ();

	public static void Shuffle<T>(this IList<T> list) {  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = rng.Next(n + 1);  
			T value = list [k];  
			list [k] = list [n];  
			list [n] = value;  
		}  
	}
}
