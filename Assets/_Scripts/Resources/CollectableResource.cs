using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CollectableResource : BaseResource {

	// Use this for initialization
	void Start () {

    // CollectableResourceData savedData = Load ();

		// if (savedData.empty) {

		// } else {
		// 	count = savedData.count;
		// }
	}

	// Update is called once per frame
	void Update () {}

	public override float GetSliderValue() {
		return 0.0f;
	}

	// void OnApplicationQuit() {
	// 	Save ();
	// }

	// protected void Save() {
	// 	BinaryFormatter bf = new BinaryFormatter ();
	// 	FileStream file = File.Create (Application.persistentDataPath + "/resource." + baseID + ".dat");

	// 	CollectableResourceData data = new CollectableResourceData ();
	// 	data.count = count;
	// 	data.fullCount = fullCount;
	// 	data.limit = limit;

	// 	bf.Serialize (file, data);
	// 	file.Close ();
	// }

	// protected CollectableResourceData Load() {
	// 	if (File.Exists (Application.persistentDataPath + "/resource." + baseID + ".dat")) {
	// 		BinaryFormatter bf = new BinaryFormatter ();
	// 		FileStream file = File.Open (Application.persistentDataPath + "/resource." + baseID + ".dat", FileMode.Open);
  //     CollectableResourceData data = (CollectableResourceData)bf.Deserialize (file);
	// 		file.Close ();

	// 		return data;
	// 	}

	// 	return new CollectableResourceData (true);
	// }
}

[Serializable]
public class CollectableResourceData {
	public int count;
	public double fullCount;
	public int limit;

	public bool empty;

	public CollectableResourceData(bool isEmpty = false) {
		empty = isEmpty;
	}
}
