using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	protected float elapsedGrowthTime = 0;
	protected bool debrisEnabled = true;
	protected short growthTicks = 0;

	public Debris ()
	{
		growthTicks = GameConstants.TOTAL_GROWTH_TICKS;
	}

	virtual public bool Collect(Vector3 cp, Transform parent) {

		transform.localPosition = cp;
		transform.parent = parent;

		GetComponent<BoxCollider>().enabled = false;
		enabled = false;
		GameManager.Instance.IncrementDebrisCollected();
		return true;
	}

	void Update() {
		if (enabled) {
			elapsedGrowthTime += Time.deltaTime;

			if (elapsedGrowthTime > GameConstants.TIME_PER_TICK) {
				elapsedGrowthTime = 0;
				growthTicks--;
				if (transform.localScale.x < GameConstants.MAX_SCALE) {
					transform.localScale += GameConstants.GROWTH_INCREMENT;
				}
			}
				
			if (growthTicks == 0) {
				GameManager.Instance.DecrementPlayerHealth(GameConstants.PENALTY);
				GameManager.Instance.DestroyDebris(gameObject);
			} 
		}
	}

}
