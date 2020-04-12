using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour {

	public List<CraftingSlot> slots = new List<CraftingSlot>();
	public List<Recipe> queue = new List<Recipe>();

//	protected bool emptySlots = true;
	protected UI_CraftingController uiController;

	// Use this for initialization
	void Start () {

		uiController = FindObjectOfType<UI_CraftingController>();
		if (!uiController) {
			Debug.LogWarning ("No UI Controller");
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void AddCraftingSlot() {
		CraftingSlot ns = new CraftingSlot (this);
		slots.Add (ns);
		checkQueue (ns);
	}

	public void AddToQueue(Recipe item) {
		queue.Add (item);
		checkQueue ();
	}

	public void checkQueue() {
		foreach (CraftingSlot slot in slots) {
			checkQueue (slot);
		}
	}

	public void checkQueue(CraftingSlot slot) {
		foreach (Recipe item in queue) {
			if (slot.CanCraft (item)) {
				slot.Craft (item);

				// Remove from Queue.
				queue.RemoveAt (queue.IndexOf(item));

				// Tell UI Manager...
				gameObject.SendMessage("ChangedCrafting", slots.IndexOf(slot));

				return;
			}
		}

    gameObject.SendMessage("FinishedCrafting", slots.IndexOf(slot));
	}
}
