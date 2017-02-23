using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour {

	/** GameObject Tags **/
	public static string DEBRIS_TAG = "Debris";
	public static string SPAWN_TAG = "Spawn";

	/** Input Axis **/
	public static string HORIZONTAL_AXIS = "Horizontal";
	public static string VERTICAL_AXIS = "Vertical";

	/** Player Controller Values **/
	public static float PLAYER_SPEED = 8000.0f;
	public static float PLAYER_ROTATION_SPEED = 2;

	/** Game Manager Values **/
	public static short PLAYER_STARTING_HEALTH = 20;
	public static short DEBRIS_RESPAWN_TIME = 4;
	public static short INITIAL_DEBRIS_SPAWNS = 5;

	/** Debris Configuration **/
	public static float TIME_PER_TICK = 2;
	public static short TOTAL_GROWTH_TICKS = 10;
	public static Vector3 GROWTH_INCREMENT = new Vector3 (0.04f, 0.04f, 0.04f);
	public static float MAX_SCALE = 0.4f;

	public static short PENALTY = 10;
	public static short HEALTH_BENEFIT = 5;

}
