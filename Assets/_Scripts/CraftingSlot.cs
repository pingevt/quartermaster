using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftingSlot {

	public bool busy = false;

	CraftingManager manager;

	private GameObject currentCraftObj;
  	private Recipe currentCraftRecipe;

	public CraftingSlot(CraftingManager m) {
		manager = m;
	}

	public bool CanCraft (Recipe item) {
		// Debug.Log ("CanCraft:" + !busy);
		return !busy;
	}

	public void Craft (Recipe item) {
		busy = true;
		currentCraftObj = item.CraftItem (this);
    	currentCraftRecipe = item;
	}

	public void ItemFinishedCrafting() {
		currentCraftObj = null;
    	currentCraftRecipe = null;
		busy = false;
		manager.checkQueue (this);
	}

	public CraftingManager GetCraftingManager() {
		return manager;
	}

	public float GetProgress() {
		if (busy) {
			return (float) currentCraftObj.GetComponent<CraftItem>().GetProgress ();
		}

		return 0f;
	}

	public GameObject GetCurrentItem() {
		return currentCraftObj;
	}

	public Recipe GetCurrentRecipe() {
		return currentCraftRecipe;
	}

}
