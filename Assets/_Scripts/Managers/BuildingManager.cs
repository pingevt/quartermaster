using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BuildingManager : MonoBehaviour
{

	public List<GameObject> availableBuildingBlueprintPrefabs;
//	public List<GameObject> availableBuildingBlueprintGO;

	public GameObject blueprintBucket;
	public GameObject buildingBucket;

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

		foreach (GameObject bpPrefab in availableBuildingBlueprintPrefabs) {

			// Instantiate and add to list.
			GameObject go = Instantiate(bpPrefab, transform.position, transform.rotation) as GameObject;
			go.transform.parent = blueprintBucket.transform;

			Blueprint newBlueprint = go.GetComponent<Blueprint> ();
			availableBlueprintsDict.Add(newBlueprint.buildingId, go);
			buildableBlueprintsDict.Add(newBlueprint.buildingId, go);
			buildingCount.Add (newBlueprint.buildingId, 0);
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
			item.transform.parent = buildingBucket.transform;

			// Increment
			buildingCount[building_id]++;

			// Check For Providers.
			providerManager.CheckProviders(blueprint.gameObject);
			providerManager.CheckProviders(item.gameObject);

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
			Debug.LogWarning ("Building costs too much");
			canBuild = false;
		}

		// Check build count.
		if ((buildingCount [blueprint.buildingId] + 1) > blueprint.buildLimit) {
			Debug.LogWarning ("Already Built Limit");
			canBuild = false;
		}

		return canBuild;
	}

	public Blueprint getBlueprintFromID (string building_id) {
		GameObject buildingGO = availableBlueprintsDict[building_id];
		return buildingGO.GetComponent<Blueprint> ();
	}

	public bool ProvideBuilding(GameObject blueprintPrefab, GameObject providee) {
		Blueprint blueprint = blueprintPrefab.GetComponent<Blueprint> ();

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

		// Instantiate and add to list.
		GameObject go = Instantiate(blueprintPrefab, transform.position, transform.rotation) as GameObject;
		go.transform.parent = blueprintBucket.transform;

		Blueprint newBlueprint = go.GetComponent<Blueprint> ();

		availableBlueprintsDict.Add (newBlueprint.buildingId, go);
		buildableBlueprintsDict.Add (newBlueprint.buildingId, go);
		buildingCount.Add (newBlueprint.buildingId, 0);

		updated = true;

		return true; 
	}

	public bool ProvideBuildings(BuildingProvider bp, GameObject providee) {

		foreach (GameObject buildingPrefab in bp.objects) {
			ProvideBuilding (buildingPrefab, providee);
		}

		bp.ClaimProvider ();
		return true;
	}
}
