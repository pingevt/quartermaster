using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseResource : MonoBehaviour {

	public ResourceType baseID;

	public int count = 0;
	public double fullCount = 0;
	public int limit = 10;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public virtual bool CheckAvailable(int checkCount) {
		if (checkCount < count)
			return true;

		return false;
	}

	public virtual bool UseResources(int useCount) {
		if (useCount <= count) {
			count -= useCount;
			return true;
		}

		return false;
  }

  public virtual bool AddResources(int addCount) {
		count += addCount;
		return true;
  }

	public virtual float GetSliderValue() {
		float amt = (float) (fullCount - Math.Truncate(fullCount));
		return amt;
	}
}
