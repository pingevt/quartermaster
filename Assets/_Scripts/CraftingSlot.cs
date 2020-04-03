using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftingSlot {

	public CraftingManager manager;

	public bool busy = false;

	public CraftingSlot(CraftingManager m) {
		manager = m;
	}

	public bool CanCraft (Recipe item) {
		Debug.Log ("CanCraft:" + !busy);

		return !busy;
	}

	public void Craft (Recipe item) {
		busy = true;
		item.CraftItem (this);
	}

	public void ItemFinishedCrafting() {
		busy = false;
		manager.checkQueue (this);
	}
}
