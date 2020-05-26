using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using UnityEngine.Analytics;
using NUnit.Framework.Internal;

public class BaseProvider : MonoBehaviour {

	[SerializeField]
	private bool hasBeenProvided = false;

	public GameObject[] objects;

	private List<ProviderRequirement> requirements = new List<ProviderRequirement>();

	[Space(30)]
	[Header("Requirements")]
	public ProvReqBuildingLevel buildingLevelReq;
	[Space(10)]
	public ProvReqAvailableBuildings availBbuildingReq;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<ProviderRequirement> getRequirements() {

		requirements.Clear ();

		if (buildingLevelReq.level > 0) {
			requirements.Add (buildingLevelReq);
		}

		if (availBbuildingReq.buildingIds.Count != 0) {
			requirements.Add (availBbuildingReq);
		}

		return requirements;
	}

	public bool isValid() {
//		Debug.Log ("-- isValid:: ");

		if (hasBeenProvided)
			return false;

		getRequirements ();

//		Debug.Log ("Requirements Count: " + requirements.Count.ToString());

		foreach (ProviderRequirement req in requirements) {

//			Debug.Log (req);

			if (!req.validate(gameObject)) {
				return false;
			}
		}

		return true;
	}

	public bool ClaimProvider() {
		hasBeenProvided = true;
		return true;
	}
}

[Serializable]
public class ProviderRequirement {

	public virtual bool validate(GameObject providee) {
		return true;
	}
}

[Serializable]
public class ProvReqBuildingLevel : ProviderRequirement {
	public int level;

	public override bool validate(GameObject providee) {
//		Debug.Log ("VALIDATE Requirement");
//		Debug.Log (level);
//		Debug.Log (providee.GetComponent<BaseBuilding> ());
		if (providee.GetComponent<BaseBuilding>().lvl >= level) { 
			return true;
		}

		return false;
	}
}

[Serializable]
public class ProvReqAvailableBuildings : ProviderRequirement {
	public List<string> buildingIds;

	new public bool validate(GameObject providee) {

//		BuildingManager buildingManager = GameObject.FindObjectOfType<BuildingManager>();
		
		return false;
	}
}
