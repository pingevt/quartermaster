using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingElementUI : MonoBehaviour {

	public Slider slider;
	public Image sliderBG;
	public Image recipeImg;

	public Color activBGColor;
	public Color inactivBGColor;

	private CraftingSlot slot;
	private bool active;

	// Use this for initialization
	void Start () {
		SetInactive ();
	}

	// Update is called once per frame
	void Update () {
		if (slot.busy) {

			if (!active) {
				SetActive ();
			}

			SetSliderVal (slot.GetProgress ());
//			SetSliderVal (slot.GetProgress ());
		}
	}

	public void SetSlot (CraftingSlot s) {
		slot = s;
	}

	public void SetSprite(Sprite img) {
		recipeImg.sprite = img;
	}

	public void SetSliderVal(float val) {
		slider.value = val;
	}

	public void SetInactive() {
		active = false;
		recipeImg.enabled = false;
		recipeImg.sprite = null;
		slider.value = 0;
		sliderBG.color = inactivBGColor;
	}

	public void SetActive() {
		active = true;
		slider.value = 0;
		recipeImg.enabled = true;
		sliderBG.color = activBGColor;
	}
}
