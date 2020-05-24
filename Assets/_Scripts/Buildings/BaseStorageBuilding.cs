using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStorageBuilding : BaseBuilding {
	
  	public int storageCapacity;
	public List<GameObject> storage;

	private WarehouseManager warehouseManager;


	void Start() {
		// Initiate warehouseManager.
		warehouseManager = FindObjectOfType<WarehouseManager>();
		if (!warehouseManager) {
			Debug.LogWarning ("No WarehouseManager");
		}

		warehouseManager.ProvideWarehouse (gameObject);
    }

    void Update() {

    }

	public bool hasSpace() {
		return (storage.Count < storageCapacity);
	}

	public bool canStoreItem(GameObject item) {
		return hasSpace();
	}

	public void storeItem(GameObject item) {
		storage.Add (item);
	}

	public void removeItem(GameObject item) {
		
		int index = storage.IndexOf(item);
		storage.RemoveAt (index);
	}
}
