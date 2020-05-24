using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Graphs;

public class CraftingManager : MonoBehaviour {

	public List<Recipe> queue = new List<Recipe>();

	public Dictionary<string, GameObject> craftingSlotsDict = new Dictionary<string, GameObject>();

	public GameObject craftingSlotBucket;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

//	public void AddCraftingSlot(GameObject slotGO) {
//		CraftingSlot slot = slotGO.GetComponent<CraftingSlot> ();
//		if (slot == null) {
//			Debug.LogWarning ("No crafting Slot");
//			return;
//		}
//
//		// Check if already available.
//		if (craftingSlotsDict.ContainsKey (slot.craftingSlotId)) {
//			Debug.LogWarning ("Crafting Slot already in the system");
//			return;
//		}
//
//		craftingSlotsDict.Add (slot.craftingSlotId, slotGO);
////		CraftingSlot ns = new CraftingSlot (this);
////		craftingSlotsDict.Add (ns);
////		checkQueue (ns);
//	}

	public void AddToQueue(Recipe item) {
//		queue.Add (item);
//		checkQueue ();
	}

	public void checkQueue() {
//		foreach (CraftingSlot slot in slots) {
//			checkQueue (slot);
//		}
	}

	public void checkQueue(CraftingSlot slot) {
//		foreach (Recipe item in queue) {
//			if (slot.CanCraft (item)) {
//				slot.Craft (item);
//
//				// Remove from Queue.
//				queue.RemoveAt (queue.IndexOf(item));
//
//				// Tell UI Manager...
//				gameObject.SendMessage("ChangedCrafting", slots.IndexOf(slot));
//
//				return;
//			}
//		}
//
//    	gameObject.SendMessage("FinishedCrafting", slots.IndexOf(slot));
	}

	public bool ProvideCraftSlot(GameObject slotGO) {
		
		CraftingSlot slot = slotGO.GetComponent<CraftingSlot> ();
		Debug.Log (slot.craftingSlotId);
		if (slot == null) {
			Debug.LogWarning ("No crafting Slot");
			return false;
		}

		// Check if already available.
		if (craftingSlotsDict.ContainsKey (slot.craftingSlotId)) {
			Debug.LogWarning ("Crafting Slot already in the system");
			return false;
		}

		// Instantiate and add to list.
		GameObject go = Instantiate(slotGO, transform.position, transform.rotation) as GameObject;
		go.transform.parent = craftingSlotBucket.transform;

	
		craftingSlotsDict.Add (slot.craftingSlotId, go);
		return true;
	}

	public bool ProvideCraftSlots(CraftSlotProvider csp) {

		foreach (GameObject slotGO in csp.objects) {
			ProvideCraftSlot (slotGO);
		}

		return true;
	}
}
