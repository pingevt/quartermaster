using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ResourceController : MonoBehaviour {

	public GameObject sliderPrefab;
	public Canvas canvas;

	public int resourceSpacing = 50;

	protected ResourceManager resourceManager;

	public Dictionary<string, GameObject> resourceUIDict = new Dictionary<string, GameObject>();

	// Use this for initialization
	void Start () {
		resourceManager = FindObjectOfType<ResourceManager>();
		if (!resourceManager) {
			Debug.LogWarning ("No Resource Manager");
		}
	}

	// Update is called once per frame
	void Update () {
		foreach (KeyValuePair<string, GameObject> resource in resourceManager.resourceDict) {
			if (resourceUIDict.ContainsKey (resource.Key)) {
				UpdateResoureSlider (resource.Key);
			} else {
				AddResourceSlider (resource.Key, resource.Value);
			}
		}
	}

	public void AddResourceSlider(string type, GameObject resource) {

		GameObject slider = Instantiate(sliderPrefab, new Vector3 (0f, 0f, 0f), canvas.transform.rotation) as GameObject;
		slider.transform.SetParent (canvas.transform);

		RectTransform rt = slider.GetComponent<RectTransform> ();

		Vector3 newPos = new Vector3 (0, (resourceSpacing * resourceUIDict.Count), 0);

		rt.anchoredPosition = newPos;

		resourceUIDict.Add (type, slider);

		// Set Label.
		slider.GetComponent<ResourceElementUI> ().SetLabel(resource.GetComponent<BaseResource> ().resourceId.ToString());
	}

	public void UpdateResoureSlider (string type) {
		BaseResource resource = resourceManager.resourceDict [type].GetComponent<BaseResource> ();
		GameObject sliderGO = resourceUIDict[type];

		sliderGO.GetComponent<ResourceElementUI> ().SetSliderVal(resource.GetSliderValue());
		sliderGO.GetComponent<ResourceElementUI> ().SetCount(resource.count.ToString());
	}
}
