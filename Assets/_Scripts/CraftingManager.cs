using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Graphs;

public class CraftingManager : MonoBehaviour {


	public List<CraftingSlot> slots = new List<CraftingSlot>();

	public List<Recipe> queue = new List<Recipe>();

//	protected bool emptySlots = true;

	// Use this for initialization
	void Start () {
//		AddCraftingSlot ();
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

//	public void TriggerEmptyCraftSlot (CraftingSlot slot) {
//		checkQueue (slot);
//	}

	public void checkQueue() {
		Debug.Log ("CheckingQueue");
		foreach (CraftingSlot slot in slots) {
			checkQueue (slot);
		}
	}

	public void checkQueue(CraftingSlot slot) {

		Debug.Log ("CheckingQueue specific slot.");

		foreach (Recipe item in queue) {
			if (slot.CanCraft (item)) {
				slot.Craft (item);

				// Remove from Queue.
				queue.RemoveAt (queue.IndexOf(item));

				break;
			}
		}
	}
}
