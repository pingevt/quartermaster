using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftingSlot : MonoBehaviour {

	public string craftingSlotId;

	public bool busy = false;


	public GameObject currentCraftObj;
	public Recipe currentCraftRecipe;

	public CraftingManager craftingManager;

	void Start () {
		craftingManager = FindObjectOfType<CraftingManager>();
		if (!craftingManager) {
			Debug.LogWarning ("No Crafting Manager");
		}

	}

	public bool CanCraft (Recipe item) {
		Debug.Log ("Checking Can Craft: !" + busy.ToString ());
		return !busy;
	}

	public bool TryToCraft (Recipe recipe) {
		busy = true;

		currentCraftObj = recipe.BeginCraftItem (this);

		if (currentCraftObj != null) {
			currentCraftRecipe = recipe;

			Debug.Log (currentCraftRecipe.recipeTitle);

			return true;
		}

		busy = false;

		return false;

	}

	public void ItemFinishedCrafting() {
		currentCraftObj = null;
    	currentCraftRecipe = null;
		busy = false;
		craftingManager.checkQueue (this);
	}

	public CraftingManager GetCraftingManager() {
		return craftingManager;
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
