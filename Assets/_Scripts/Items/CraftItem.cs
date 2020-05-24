using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftItem : MonoBehaviour {

	// Crafting
	public bool crafting;
	public CraftingSlot craftingSlot;

	public double craftingStartTime;
	public double craftingTimeLength;

	[Space(10)]
	// Base Props
	public int baseAttack = 0;
	public int baseDefense = 0;

	[Space(10)]
	// Props
	public int attack = 0;
	public int defense = 0;

	protected WarehouseManager warehouseManager;

	// Use this for initialization
	void Start () {

		warehouseManager = FindObjectOfType<WarehouseManager>();
		if (!warehouseManager) {
			Debug.LogWarning ("No Warehouse Manager");
		}

		StartCrafting ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCraftingTime(double time) { 
		craftingTimeLength = time;
	}

	public void SetCraftingSlot(CraftingSlot slot) { 
		craftingSlot = slot;
	}

	public double GetProgress() {
		return (Epoch.SecondsElapsed (Epoch.Current (), craftingStartTime)) / craftingTimeLength;
	}

	protected void StartCrafting() {
		crafting = true;
		craftingStartTime = Epoch.Current ();

		StartCoroutine("CheckForCrafting");
	}

	IEnumerator CheckForCrafting() {
		double passedTime = Epoch.SecondsElapsed (Epoch.Current (), craftingStartTime);

		while (passedTime < craftingTimeLength) {
			yield return new WaitForSeconds (1f);
			passedTime = Epoch.SecondsElapsed (Epoch.Current (), craftingStartTime);
		}
			
//		FinishCrafting ();
		StartCoroutine("CheckForStorage");
	}

	IEnumerator CheckForStorage() {
		bool canStore = warehouseManager.canStoreItem (this.gameObject);

		while (!canStore) {
			yield return new WaitForSeconds (1f);
			canStore = warehouseManager.canStoreItem (this.gameObject);
		}

		warehouseManager.storeItem (this.gameObject);
		FinishCrafting ();
	}

	protected void FinishCrafting() {
		crafting = false;
		craftingSlot.ItemFinishedCrafting ();
		craftingSlot = null;
		SetItemProps ();
	}

	protected void SetItemProps() {
		attack = baseAttack;
		defense = baseDefense;
	}
}
