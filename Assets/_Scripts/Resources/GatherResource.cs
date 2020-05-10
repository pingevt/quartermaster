using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GatherResource : BaseResource {

	public bool collecting = false;

	public double collectingStartTime;
	public double timeToGather;

	public int collectMin = 1;
	public int collectMax = 3;

	// Use this for initialization
	void Start () {

		// GatherResourceData savedData = Load ();

		// if (savedData.empty) {
		// 	startCollecting ();
		// } else {
		// 	count = savedData.count;
		// 	collecting = savedData.collecting;
		// 	collectingStartTime = savedData.collectingStartTime;
		// 	timeToGather = savedData.timeToGather;

		// 	collectMin = savedData.collectMin;
		// 	collectMin = savedData.collectMin;

		// }
	}

	// Update is called once per frame
	void Update () {
		if (collecting) {
			// check what we should have.
			double difference = Epoch.SecondsElapsed (Epoch.Current (), collectingStartTime);

			if (difference > timeToGather) {
				collectingStartTime += timeToGather;

				gatherResource ();
			}
		}
	}

	void startCollecting() {
		collectingStartTime = Epoch.Current();
		collecting = true;
	}

	void gatherResource() {
		int actualGatherAmount = UnityEngine.Random.Range (collectMin, (collectMax + 1));
//		Debug.Log ("Gathered: " + actualGatherAmount.ToString() + " " + baseID.ToString());

		if ((count + actualGatherAmount) > limit) {

			Debug.Log ("Reached Limit");
			count = limit;
			collecting = false;
		} else {
			Debug.Log ("Still Gathering");
			count += actualGatherAmount;
			collecting = true;
		}
	}

	public override bool UseResources(int useCount) {
		if (useCount <= count) {
			count -= useCount;

			if (count < limit && !collecting) {
				startCollecting ();
			}

			return true;
		}

		return false;
	}

	public override float GetSliderValue() {
		double difference = Epoch.SecondsElapsed (Epoch.Current (), collectingStartTime);
		float amt = (float) (difference / timeToGather);

//		Debug.Log ("Gather: " + amt.ToString());
		return amt;
	}

	// void OnApplicationQuit() {
	// 	Save ();
	// }

	// protected void Save() {
	// 	BinaryFormatter bf = new BinaryFormatter ();
	// 	FileStream file = File.Create (Application.persistentDataPath + "/resource." + baseID + ".dat");

	// 	GatherResourceData data = new GatherResourceData ();
	// 	data.count = count;
	// 	data.fullCount = fullCount;
	// 	data.limit = limit;
	// 	data.collecting = collecting;
	// 	data.collectingStartTime = collectingStartTime;
	// 	data.timeToGather = timeToGather;
	// 	data.collectMin = collectMin;
	// 	data.collectMax = collectMax;

	// 	bf.Serialize (file, data);
	// 	file.Close ();
	// }

	// protected GatherResourceData Load() {
  //   Debug.Log(Application.persistentDataPath);

  //   if (File.Exists (Application.persistentDataPath + "/resource." + baseID + ".dat")) {
	// 		BinaryFormatter bf = new BinaryFormatter ();
	// 		FileStream file = File.Open (Application.persistentDataPath + "/resource." + baseID + ".dat", FileMode.Open);
	// 		GatherResourceData data = (GatherResourceData)bf.Deserialize (file);
	// 		file.Close ();

	// 		return data;
	// 	}

	// 	return new GatherResourceData (true);
	// }
}

[Serializable]
public class GatherResourceData {
	public int count;
	public double fullCount;
	public int limit;

	public bool collecting;

	public double collectingStartTime;
	public double timeToGather;

	public int collectMin;
	public int collectMax;

	public bool empty;

	public GatherResourceData(bool isEmpty = false) {
		empty = isEmpty;
	}
}
