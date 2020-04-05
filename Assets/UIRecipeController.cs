using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRecipeController : MonoBehaviour {

	public GameObject UIPrefab;
	public Canvas canvas;

	public int recipeSpacing = 50;

	protected RecipeManager recipeManager;
	protected CraftingManager craftingManager;

	public Dictionary<string, GameObject> recipeUIDict = new Dictionary<string, GameObject>();

	// Use this for initialization
	void Start () {
		recipeManager = FindObjectOfType<RecipeManager>();
		if (!recipeManager) {
			Debug.LogWarning ("No Recipe Manager");
		}

		craftingManager = FindObjectOfType<CraftingManager>();
		if (!craftingManager) {
			Debug.LogWarning ("No Crafting Manager");
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (KeyValuePair<string, GameObject> recipe in recipeManager.recipeDict) {
			if (recipeUIDict.ContainsKey (recipe.Key)) {
				Debug.Log ("Update Button");

//								UpdateRecipeSlider (recipe.Key);
			} else {
				AddRecipeSlider (recipe.Key, recipe.Value);
			}
		}
	}

	public void AddRecipeSlider(string type, GameObject resource) {

		GameObject button = Instantiate(UIPrefab, new Vector3 (0f, 0f, 0f), canvas.transform.rotation) as GameObject;
		button.transform.SetParent (canvas.transform);

		RectTransform rt = button.GetComponent<RectTransform> ();

		Vector3 newPos = new Vector3 (0f, (recipeSpacing * recipeUIDict.Count), 0f);
		rt.anchoredPosition = newPos;

		recipeUIDict.Add (type, button);

		// Set Image.
		Sprite sp = resource.GetComponent<Recipe> ().recipeImage;
		button.GetComponent<RecipeUI> ().SetSprite(sp);

		// Set Button
		resource.GetComponent<Recipe> ().AddButton (button.GetComponentInChildren<Button>());
	}

//	public void UpdateResoureSlider (ResourceType type) {
//		BaseResource resource = recipeManager.recipeDict [type].GetComponent<BaseResource> ();
//		GameObject sliderGO = recipeUIDict[type];
//
//		sliderGO.GetComponent<ResourceUI> ().SetSliderVal(resource.GetSliderValue());
//		sliderGO.GetComponent<ResourceUI> ().SetCount(resource.count.ToString());
//	}
}
