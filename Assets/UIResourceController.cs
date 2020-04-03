using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIResourceController : MonoBehaviour {

	public GameObject sliderPrefab;
	public Canvas canvas;

	public int resourceSpacing = 50;

	protected ResourceManager resourceManager;

	public Dictionary<ResourceType, GameObject> resourceUIDict = new Dictionary<ResourceType, GameObject>();

	// Use this for initialization
	void Start () {
		resourceManager = FindObjectOfType<ResourceManager>();
		if (!resourceManager) {
			Debug.LogWarning ("No Resource Manager");
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (KeyValuePair<ResourceType, GameObject> resource in resourceManager.resourceDict) {
			if (resourceUIDict.ContainsKey (resource.Key)) {
				Debug.Log ("Update Slider");

				UpdateResoureSlider (resource.Key);
			} else {
				AddResourceSlider (resource.Key, resource.Value);
			}
		}
	}

	public void AddResourceSlider(ResourceType type, GameObject resource) {

		GameObject slider = Instantiate(sliderPrefab, transform.position, transform.rotation) as GameObject;
		slider.transform.parent = canvas.transform;

		RectTransform rt = slider.GetComponent<RectTransform> ();

		Vector3 newPos = new Vector3 (rt.localPosition.x, (rt.localPosition.y + resourceSpacing * resourceUIDict.Count), rt.localPosition.z);

		rt.localPosition = newPos;

		resourceUIDict.Add (type, slider);

		// Set Label.
		slider.GetComponentInChildren<Text> ().text = resource.GetComponent<BaseResource> ().baseID.ToString();
	}

	public void UpdateResoureSlider (ResourceType type) {
		BaseResource resource = resourceManager.resourceDict [type].GetComponent<BaseResource> ();
		GameObject sliderGO = resourceUIDict[type];

		sliderGO.GetComponent<Slider> ().value = resource.GetSliderValue();
	}
}
