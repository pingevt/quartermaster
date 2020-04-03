using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class RenewableResource : BaseResource {

	public bool collecting = false;
	public double collectingStartTime;
	public int collectingBase = 0;
	public float rate = 10f;

	// Use this for initialization
	void Start () {
		RenewableResourceData savedData = Load ();
		if (savedData.empty) {
			startCollecting ();
		} else {
			count = savedData.count;
			fullCount = savedData.fullCount;
			limit = savedData.limit;
			collecting = savedData.collecting;
			collectingStartTime = savedData.collectingStartTime;
			collectingBase = savedData.collectingBase;
			rate = savedData.rate;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (collecting) {
			// check what we should have.
			double difference = Epoch.SecondsElapsed (Epoch.Current (), collectingStartTime);

			fullCount = (double)(rate / 60f) * difference;

			if (fullCount + collectingBase > (double)limit) {
				count = limit;
				collecting = false;
				fullCount = 0;
			} else {
				count = (int)fullCount + collectingBase;
			}
		}


		TextMesh text = GetComponentInChildren<TextMesh> ();
		text.text = count.ToString ();
	}

	public override bool UseResources(int useCount) {
		if (useCount <= count) {

			count -= useCount;
			collectingBase = count;

//			Debug.Log (Epoch.Current());
//			Debug.Log ((60f / rate));
//			Debug.Log ((fullCount - Math.Truncate(fullCount)));
//			Debug.Log ((60f / rate) * (fullCount - Math.Truncate(fullCount)));

			collectingStartTime = Epoch.Current() - (60f / rate) * (fullCount - Math.Truncate(fullCount)) ;

//			Debug.Log (collectingTime);

			if (count < limit && !collecting) {
				startCollecting ();
			}

			return true;

		} else {
			return false;
		}
	}

	void startCollecting() {
		collectingStartTime = Epoch.Current();
		collecting = true;
	}

	void OnApplicationQuit() {
		Save ();
	}

	protected void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/resource." + baseID + ".dat");
//		Debug.Log (Application.persistentDataPath);

		RenewableResourceData data = new RenewableResourceData ();
		data.count = count;
		data.fullCount = fullCount;
		data.limit = limit;
		data.collecting = collecting;
		data.collectingStartTime = collectingStartTime;
		data.collectingBase = collectingBase;
		data.rate = rate;

		bf.Serialize (file, data);
		file.Close ();
	}

	protected RenewableResourceData Load() {
		if (File.Exists (Application.persistentDataPath + "/resource." + baseID + ".dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/resource." + baseID + ".dat", FileMode.Open);
			RenewableResourceData data = (RenewableResourceData)bf.Deserialize (file);
			file.Close ();

			return data;
		}

		return new RenewableResourceData (true);
	}
}

[Serializable]
public class RenewableResourceData {
	public int count;
	public double fullCount;
	public int limit;

	public bool collecting;
	public double collectingStartTime;
	public int collectingBase;
	public float rate;

	public bool empty;

	public RenewableResourceData(bool isEmpty = false) {
		empty = isEmpty;
	}
}