﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour {

	public string recipeID = "";
	public string recipeTitle = "";
	public List<ResourceNeed> resourceNeeds;
	public double baseCraftTime; // in seconds.

	public GameObject itemPrefab;

	public Sprite recipeImage;
	 
	protected ResourceManager resourceManager;
	protected RecipeManager recipeManager;

	// Use this for initialization
	void Start () {
		resourceManager = FindObjectOfType<ResourceManager>();
		if (!resourceManager) {
			Debug.LogWarning ("No Resource Manager");
		}

		recipeManager = FindObjectOfType<RecipeManager>();
		if (!recipeManager) {
			Debug.LogWarning ("No Recipe Manager");
		}
	}

	// Update is called once per frame
	void Update () {
		
	} 

	public void AddButton (Button btn) {
		btn.onClick.AddListener (addToQueue);
	}

	public void addToQueue() {
//		Debug.Log ("ADD TO QUEUE");
		recipeManager.queueRecipe (recipeID);
	}

	public GameObject BeginCraftItem(CraftingSlot slot) {

		Debug.Log ("Crafting Item: " + recipeTitle);

		// Check Resource Availability and consume.
		if (resourceManager.AvailableResources (resourceNeeds)) {
			if (resourceManager.ConsumeResources (resourceNeeds)) {
			
				GameObject item = Instantiate (itemPrefab, transform.position, transform.rotation) as GameObject;
				item.transform.parent = slot.GetCraftingManager().transform;
				item.GetComponent<CraftItem> ().SetCraftingTime (baseCraftTime);
				item.GetComponent<CraftItem> ().SetCraftingSlot (slot);

				return item;
			} else {
				Debug.LogWarning("Cannot consume resource: ");
			}
		} else {
			Debug.LogWarning("Resrouces are not available: ");
		}

		return null;
	}
}

