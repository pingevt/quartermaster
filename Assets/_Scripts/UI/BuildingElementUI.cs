﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingElementUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetSprite(Sprite img) {
		Image imgScript = GetComponent<Image> ();
		imgScript.sprite = img;
	}
}
