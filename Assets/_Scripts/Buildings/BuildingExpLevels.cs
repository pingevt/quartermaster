using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingExpLevels {
	private Dictionary<int, int> experienceLevels = new Dictionary<int, int>();

	public BuildingExpLevels() {
		experienceLevels.Add (2, 100);
		experienceLevels.Add (3, 500);
		experienceLevels.Add (4, 1000);
		experienceLevels.Add (5, 1500);
		experienceLevels.Add (6, 2500);
	}

	public int returnLevel(int exp) {
		foreach (KeyValuePair<int, int> level in experienceLevels) {
			if (level.Value > exp) {

				return level.Key - 1;
			}
		}

		return experienceLevels.Count;
	}
}
