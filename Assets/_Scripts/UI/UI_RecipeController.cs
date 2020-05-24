using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RecipeController : MonoBehaviour {

	public GameObject UIPrefab;
	public GameObject UIScrollerPrefab;
	protected GameObject UIScroller;
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

		// Instantiate Scroll View.
		UIScroller = Instantiate(UIScrollerPrefab, UIScrollerPrefab.transform.position, UIScrollerPrefab.transform.rotation) as GameObject;
		UIScroller.transform.SetParent(canvas.transform, false);
	}

	// Update is called once per frame
	void Update () {
		foreach (KeyValuePair<string, GameObject> recipe in recipeManager.recipeDict) {
			if (recipeUIDict.ContainsKey (recipe.Key)) {
//				Debug.Log ("Update Button");
//				UpdateRecipeSlider (recipe.Key);
			} else {
				AddRecipeSlider (recipe.Key, recipe.Value);
			}
		}
	}

	public void AddRecipeSlider(string type, GameObject resource) {

		int index = recipeUIDict.Count;

		GameObject button = Instantiate(UIPrefab, new Vector3 (0f, 0f, 0f), canvas.transform.rotation) as GameObject;
		button.transform.SetParent(UIScroller.transform.GetChild(0).transform.GetChild(0), false);

		RectTransform rt = button.GetComponent<RectTransform> ();

		float buttonHeight = (rt.sizeDelta.y);
		float newY = ((30 * index) + (rt.sizeDelta.y * index)) * -1 + rt.anchoredPosition.y;

		Vector3 newPos = new Vector3 (rt.anchoredPosition.x, newY, 0f);
		rt.anchoredPosition = newPos;
		recipeUIDict.Add (type, button);

		// Set Image.
		Recipe recipe = resource.GetComponent<Recipe> ();
		Sprite sp = recipe.recipeImage;
		button.GetComponent<RecipeElementUI> ().SetSprite(sp); 

		// Set Title.
		button.GetComponent<RecipeElementUI>().SetTitle(recipe.recipeTitle);

		// Set Button
		resource.GetComponent<Recipe> ().AddButton (button.GetComponentInChildren<Button>());

		// Set Scroll Height.
		float contentHeight = (newY * -1) + buttonHeight + 10;
		canvas.GetComponentInChildren<ScrollUI>().SetContentHeight(contentHeight);
	}
}
