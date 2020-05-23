using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScrollUI : MonoBehaviour {

	public RectTransform content;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetContentHeight(float height) {
		content.sizeDelta = new Vector2 (content.sizeDelta.x, height);
	}
}
