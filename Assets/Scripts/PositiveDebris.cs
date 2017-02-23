using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveDebris : Debris {

	public override bool Collect(Vector3 cp, Transform parent) {
		GameManager.Instance.IncrementPlayerHealth((short)(GameConstants.HEALTH_BENEFIT + elapsedGrowthTime));
		return base.Collect(cp, parent);
	}

}
