using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public List<GameObject> availableBuildings;
	public Dictionary<string, GameObject> availableBuildingsDict = new Dictionary<string, GameObject>();
	public Dictionary<string, int> buildingCount = new Dictionary<string, int>();

	private Player player;

    void Start()
    {
		// Initiate player.
		player = FindObjectOfType<Player>();
		if (!player) {
			Debug.LogWarning ("No Player");
		}

        foreach (GameObject b in availableBuildings) {
			availableBuildingsDict.Add(b.GetComponent<BaseBuilding>().buildingId, b);
			buildingCount.Add (b.GetComponent<BaseBuilding>().buildingId, 0);
        }
    }

    void Update()
    {

    }

	public void buildBuilding(string building_id) {
		Debug.Log (building_id);
		BaseBuilding building = getBuildingFromID (building_id);
		
		Debug.Log (canBuildBuilding(building));

		// If we can...
		if (canBuildBuilding(building)) {

			// Charge Player.
			player.charge(building.cost);

			// Add GO.

			// Check For Providers.
		}

	}

	private bool canBuildBuilding(BaseBuilding building) {
		bool canBuild = true;

		// Check price.
		if (player.monies < building.cost) {
			canBuild = false;
		}

		return canBuild;
	}

	public BaseBuilding getBuildingFromID (string building_id) {
		GameObject buildingGO = availableBuildingsDict[building_id];
		return buildingGO.GetComponent<BaseBuilding> ();
	}
}
