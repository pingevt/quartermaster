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
		
		Debug.Log (content.sizeDelta.x);
		Debug.Log (height);

		Debug.Log (content.sizeDelta);

		content.sizeDelta = new Vector2 (content.sizeDelta.x, height);
	}
}
