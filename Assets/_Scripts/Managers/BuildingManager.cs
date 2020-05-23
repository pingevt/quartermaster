using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BuildingManager : MonoBehaviour
{

    public List<GameObject> availableBuildingBlueprints;

	public Dictionary<string, GameObject> availableBlueprintsDict = new Dictionary<string, GameObject>();
	public Dictionary<string, GameObject> buildableBlueprintsDict = new Dictionary<string, GameObject>();
//	public Dictionary<string, GameObject> builtBluildingsDict = new Dictionary<string, GameObject>();

	public Dictionary<string, int> buildingCount = new Dictionary<string, int>();

	private Player player;

    void Start()
    {
		// Initiate player.
		player = FindObjectOfType<Player>();
		if (!player) {
			Debug.LogWarning ("No Player");
		}

		foreach (GameObject b in availableBuildingBlueprints) {
			availableBlueprintsDict.Add(b.GetComponent<Blueprint>().buildingId, b);
			buildableBlueprintsDict.Add(b.GetComponent<Blueprint>().buildingId, b);
			buildingCount.Add (b.GetComponent<Blueprint>().buildingId, 0);
        }
    }

    void Update()
    {

    }

	public void buildBuilding(string building_id) {
		Debug.Log (building_id);
		Blueprint blueprint = getBlueprintFromID (building_id);
		Debug.Log (canBuildBuilding(blueprint));

		// If we can...
		if (canBuildBuilding(blueprint)) {
//			int buildingCount = buildingCount [building_id] + 1;

			// Charge Player.
			player.charge(blueprint.cost);

			// Add GO.
			GameObject item = Instantiate (blueprint.itemPrefab, transform.position, transform.rotation) as GameObject;
			item.transform.parent = transform;

			// Increment
			buildingCount[building_id]++;

			// Check For Providers.


			// Update Buildable list.
			if (buildingCount[building_id] >= blueprint.buildLimit) {
				buildableBlueprintsDict.Remove (building_id);
			}
		}

	}

	private bool canBuildBuilding(Blueprint blueprint) {
		bool canBuild = true;

		// Check price.
		if (player.monies < blueprint.cost) {
			canBuild = false;
		}

		// Check build count.
		if ((buildingCount [blueprint.buildingId] + 1) > blueprint.buildLimit) {
			canBuild = false;
		}

		return canBuild;
	}

	public Blueprint getBlueprintFromID (string building_id) {
		GameObject buildingGO = availableBlueprintsDict[building_id];
		return buildingGO.GetComponent<Blueprint> ();
	}
}
