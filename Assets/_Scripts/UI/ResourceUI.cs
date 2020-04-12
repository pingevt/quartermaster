using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {

	public GameObject label;
	public GameObject count;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetLabel(string labelSt) {
		label.GetComponent<Text> ().text = labelSt;
	}

	public void SetSliderVal(float val) {
		gameObject.GetComponentInChildren<Slider> ().value = val;
	}

	public void SetCount(string countSt) {
		count.GetComponent<Text> ().text = countSt;
	}
}
