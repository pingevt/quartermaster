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

	public void AddToQueue(Recipe item) {
		queue.Add (item);
		checkQueue ();
	}

	public void checkQueue() {
		foreach (KeyValuePair<string, GameObject> item in craftingSlotsDict) {
//			Debug.Log (item.Key);

			CraftingSlot slot = item.Value.GetComponent<CraftingSlot> ();
			checkQueue (slot);
		}
	}

	public void checkQueue(CraftingSlot slot) {
		foreach (Recipe item in queue) {
			if (slot.CanCraft (item)) {
				if (slot.TryToCraft (item)) {

					// Remove from Queue.
					queue.RemoveAt (queue.IndexOf (item));

					// Tell UI Manager...
					// gameObject.SendMessage ("ChangedCrafting", slot.craftingSlotUniqueId);
					gameObject.SendMessage ("SetUIElementActive", slot.craftingSlotUniqueId);

					return;
				} else {
					Debug.LogWarning ("Tried, but could not");
					return;
				}
			}
		}

		gameObject.SendMessage("FinishedCrafting", slot.craftingSlotUniqueId);
	}

	public bool ProvideCraftSlot(GameObject slotGO, GameObject providee) {
		
		CraftingSlot slot = slotGO.GetComponent<CraftingSlot> ();
		if (slot == null) {
			Debug.LogWarning ("No crafting Slot");
			return false;
		}

		// Check if already available.
		if (craftingSlotsDict.ContainsKey (slot.craftingSlotUniqueId)) {
			Debug.LogWarning ("Crafting Slot already in the system");
			return false;
		}

		// Instantiate and add to list.
		GameObject go = Instantiate(slotGO, transform.position, transform.rotation) as GameObject;
		go.transform.parent = craftingSlotBucket.transform;

		int index = craftingSlotsDict.Count;
		string uniqueId = slot.craftingSlotId + "_" + index.ToString ();
		go.GetComponent<CraftingSlot> ().craftingSlotUniqueId = uniqueId;

		go.GetComponent<CraftingSlot> ().setSourceBuilding (providee.GetComponent<BaseBuilding> ());

		craftingSlotsDict.Add (uniqueId, go);
		return true;
	}

	public bool ProvideCraftSlots(CraftSlotProvider csp, GameObject providee) {

		foreach (GameObject slotGO in csp.objects) {
			ProvideCraftSlot (slotGO, providee);
		}

		csp.ClaimProvider ();
		return true;
	}
}
