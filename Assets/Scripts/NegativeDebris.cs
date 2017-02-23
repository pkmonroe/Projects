using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeDebris : Debris {

	public override bool Collect(Vector3 cp, Transform parent) {
		GameManager.Instance.DecrementPlayerHealth((short)(elapsedGrowthTime));
		return base.Collect(cp, parent);
	}
}
