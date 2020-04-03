using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

	public string recipeID = "";
	public List<ResourceNeed> resourceNeeds;
	public double baseCraftTime; // in seconds.

	public GameObject itemPrefab;

	protected ResourceManager resourceManager;

	// Use this for initialization
	void Start () {
		resourceManager = FindObjectOfType<ResourceManager>();
		if (!resourceManager) {
			Debug.LogWarning ("No Resource Manager");
		}
	}

	// Update is called once per frame
	void Update () {
		
	} 

	public GameObject CraftItem(CraftingSlot slot) {

		// Check Resource Availability and consume.
		if (resourceManager.AvailableResources (resourceNeeds)) {
			if (resourceManager.ConsumeResources (resourceNeeds)) {
			
				GameObject item = Instantiate (itemPrefab, transform.position, transform.rotation) as GameObject;
				item.transform.parent = slot.manager.transform;
				item.GetComponent<CraftItem> ().SetCraftingTime (baseCraftTime);
				item.GetComponent<CraftItem> ().SetCraftingSlot (slot);

				return item;
			} else {
				Debug.LogWarning("Cannot consume resource: " + resourceNeeds.ToString());
			}
		} else {
			Debug.LogWarning("Resrouces are not available: " + resourceNeeds.ToString());
		}

		return null;
	}
}