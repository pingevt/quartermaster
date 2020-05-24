using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseManager : MonoBehaviour {


//	public Dictionary<string, GameObject> warehouseDict = new Dictionary<string, GameObject>();

	public List<GameObject> warehouses;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool canStoreItem(GameObject item) {
		foreach (GameObject warehouseGO in warehouses) {
			if (warehouseGO.GetComponent<BaseStorageBuilding> ().hasSpace ()
				&& warehouseGO.GetComponent<BaseStorageBuilding> ().canStoreItem (item))
				return true;
		}

		return false;
	}

	public void storeItem(GameObject item) {
		// Search All Warehouses for storage.
		foreach (GameObject warehouseGO in warehouses) {
			if (warehouseGO.GetComponent<BaseStorageBuilding> ().hasSpace ())
				warehouseGO.GetComponent<BaseStorageBuilding> ().storeItem(item);
		}
	}

	public bool ProvideWarehouse(GameObject warehouseGO) {
		warehouses.Add (warehouseGO);

		return true; 
	}

}
