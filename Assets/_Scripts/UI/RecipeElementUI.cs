﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeElementUI : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SetSprite(Sprite img) {
		Image imgScript = GetComponentInChildren<Image> ();
		imgScript.sprite = img;

	}

	public void SetTitle(string title) {
		text.text = title;
	}
}
