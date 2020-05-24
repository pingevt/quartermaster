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
	private ProviderManager providerManager;

	private bool updated = false;

    void Start()
    {
		// Initiate player.
		player = FindObjectOfType<Player>();
		if (!player) {
			Debug.LogWarning ("No Player");
		}

		providerManager = FindObjectOfType<ProviderManager>();
		if (!providerManager) {
			Debug.LogWarning ("No providerManager");
		}

		foreach (GameObject b in availableBuildingBlueprints) {
			availableBlueprintsDict.Add(b.GetComponent<Blueprint>().buildingId, b);
			buildableBlueprintsDict.Add(b.GetComponent<Blueprint>().buildingId, b);
			buildingCount.Add (b.GetComponent<Blueprint>().buildingId, 0);
        }

		updated = true;
    }

    void Update()
    {

	}

	public bool hasUpdated() {
		if (updated == true) {
			updated = false;
			return true;
		}

		return false;
	}

	public void buildBuilding(string building_id) {
//		Debug.Log (building_id);
		Blueprint blueprint = getBlueprintFromID (building_id);
//		Debug.Log (canBuildBuilding(blueprint));

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
			providerManager.CheckProviders(blueprint.gameObject);

			// Update Buildable list.
			if (buildingCount[building_id] >= blueprint.buildLimit) {
				buildableBlueprintsDict.Remove (building_id);
			}

			updated = true;
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

	public bool ProvideBuilding(GameObject blueprintGO) {
		Blueprint blueprint = blueprintGO.GetComponent<Blueprint> ();

		// Check if it is a blueprint.
		if (blueprint == null) {
			Debug.LogWarning ("No blueprint");
			return false;
		}

		// Check if already available.
		if (availableBlueprintsDict.ContainsKey (blueprint.buildingId) ||
			buildableBlueprintsDict.ContainsKey (blueprint.buildingId) ||
			buildingCount.ContainsKey (blueprint.buildingId)) {

			Debug.LogWarning ("Already in the system");

			return false;
		}

		availableBlueprintsDict.Add (blueprint.buildingId, blueprintGO);
		buildableBlueprintsDict.Add (blueprint.buildingId, blueprintGO);
		buildingCount.Add (blueprint.buildingId, 0);

		updated = true;

		return true; 
	}

	public bool ProvideBuildings(BuildingProvider bp) {

		foreach (GameObject building in bp.objects) {
			bool provided = ProvideBuilding (building);
		}

		return true;
	}
}
