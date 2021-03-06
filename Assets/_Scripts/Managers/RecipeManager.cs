﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {

	public GameObject[] recipes = new GameObject[1];

	public Dictionary<string, GameObject> recipeDict = new Dictionary<string, GameObject>();


	protected CraftingManager craftingManager;

	// Use this for initialization
	void Start () {
		craftingManager = FindObjectOfType<CraftingManager>();
		if (!craftingManager) {
			Debug.LogWarning ("No Crafting Manager");
		}

		foreach (GameObject recipe in recipes) {
			GameObject go = Instantiate(recipe, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;

			recipeDict.Add (go.GetComponent<Recipe>().recipeID, go);
		}
	}
	
	// Update is called once per frame
	void Update () { 
		
	}

	public void queueRecipe(string recipeId) {
		craftingManager.AddToQueue(recipeDict[recipeId].GetComponent<Recipe>());
	}

	public bool ProvideRecipe(GameObject rec_prefab, GameObject providee) {
		Recipe recipe = rec_prefab.GetComponent<Recipe> ();

		// Check if it is a blueprint.
		if (recipe == null) {
			Debug.LogWarning ("No recipe");
			return false;
		}

		// Check if already available.
		if (recipeDict.ContainsKey (recipe.recipeID)) {

			Debug.LogWarning ("Already in the system");

			return false;
		}

		// Instantiate and add to list.
		GameObject go = Instantiate(rec_prefab, transform.position, transform.rotation) as GameObject;
		go.transform.parent = transform;

		recipeDict.Add (go.GetComponent<Recipe>().recipeID, go);


		return true; 
	}

	public bool ProvideRecipes(RecipeProvider recp, GameObject providee) {

		foreach (GameObject recipe_prefab in recp.objects) {
			ProvideRecipe (recipe_prefab, providee);
		}

		recp.ClaimProvider ();

		return true;
	}







	
	// For testing only.
	public void queueSword() {
		craftingManager.AddToQueue(recipeDict["sword"].GetComponent<Recipe>());
	}

	public void queueStaff() {
		craftingManager.AddToQueue(recipeDict["staff"].GetComponent<Recipe>());
	}
}
	
[System.Serializable]
public class ResourceNeed {

	public string resourceID;
	public int count;

	public ResourceNeed(string id, int ct) {
		resourceID = id;
		count = ct;
	}

	public ResourceNeed() {

	}

	public override string ToString() {
		return resourceID + "::" + count.ToString ();
	}
}
