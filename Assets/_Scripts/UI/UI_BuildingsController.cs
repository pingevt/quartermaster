﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UI_BuildingsController : MonoBehaviour
{
    public GameObject UIPrefab;
    public GameObject UIScrollerPrefab;
    protected GameObject UIScroller;
    public Canvas canvas;
    private BuildingManager buildingManager;

    public Dictionary<string, GameObject> buildingUIDict = new Dictionary<string, GameObject>();

    void Start() {
        buildingManager = GetComponent<BuildingManager>();

        // Instantiate Scroll View.
        UIScroller = Instantiate(UIScrollerPrefab, UIScrollerPrefab.transform.position, UIScrollerPrefab.transform.rotation) as GameObject;
        UIScroller.transform.SetParent(canvas.transform, false);
    }

    void Update() {
        foreach (KeyValuePair<string, GameObject> building in buildingManager.availableBuildingsDict) {
            if (buildingUIDict.ContainsKey(building.Key)) {
                // Nothing at the moment.
            }
            else {
                AddBuildingButton(building.Key, building.Value);
            }
        }
    }

    private void AddBuildingButton (string building_id, GameObject buildingGO) {

		int index = buildingUIDict.Count;

        GameObject button = Instantiate(UIPrefab, UIPrefab.transform.position, UIPrefab.transform.rotation) as GameObject;
        button.transform.SetParent(UIScroller.transform.GetChild(0).transform.GetChild(0), false);

		RectTransform rt = button.GetComponent<RectTransform>();

		float buttonHeight = (rt.sizeDelta.y);
		float newY = ((30 * index) + (rt.sizeDelta.y * index)) * -1 + rt.anchoredPosition.y;

		Vector3 newPos = new Vector3(rt.anchoredPosition.x, newY, 0f);
		rt.anchoredPosition = newPos;
		Debug.Log (building_id);
		buildingUIDict.Add(building_id, button);

		// Set Image.
		BaseBuilding building = buildingGO.GetComponent<BaseBuilding>();
		Sprite sp = building.buildingImage;
		button.GetComponent<BuildingElementUI>().SetSprite(sp);

		// Set Title.

		// Set Button Action.
		button.GetComponent<Button>().onClick.AddListener(delegate {ClickedBuildingBUtton(building.buildingId); } );

		// Set Scroll Height.
		float contentHeight = (newY * -1) + buttonHeight + 10;
		canvas.GetComponentInChildren<BuildingScrollUI>().SetContentHeight(contentHeight);
    }

	void ClickedBuildingBUtton(string building_id) {
		buildingManager.buildBuilding (building_id);
	}
}
