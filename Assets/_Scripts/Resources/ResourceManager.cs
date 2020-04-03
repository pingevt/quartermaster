using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	public GameObject[] renewableResources;
	public GameObject[] gatherableResources;

	public Dictionary<ResourceType, GameObject> resourceDict = new Dictionary<ResourceType, GameObject>();

	// Use this for initialization
	void Start () {
		foreach (GameObject resource in renewableResources) {
			GameObject go = Instantiate(resource, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;

			resourceDict.Add (go.GetComponent<BaseResource>().baseID, go);
		}

		foreach (GameObject resource in gatherableResources) {
			GameObject go = Instantiate(resource, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;

			resourceDict.Add (go.GetComponent<BaseResource>().baseID, go);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool AvailableResources(List<ResourceNeed> resources) {
		bool avail = true;

		foreach (ResourceNeed need in resources) {
			if (!resourceDict [need.resourceID].GetComponent<BaseResource>().CheckAvailable (need.resourceCount)) {
				avail = false;
			}
		}

		return avail;
	}


	public bool ConsumeResources(List<ResourceNeed> resources) {

		foreach (ResourceNeed need in resources) {
//			resourceDict [need.resourceID].GetComponent<BaseResource> ().UseResources (need.resourceCount);
			ConsumeResource(need.resourceID, need.resourceCount);
		}

		return true;
	}

	public void ConsumeResource(ResourceType type, int count) {
		
		resourceDict [type].GetComponent<BaseResource> ().UseResources (count);
	}
















//	public void useResource(string resourceId, int amount) {
//		foreach (RenewableResource resource in GetComponentsInChildren<RenewableResource>()){
//			if (resource.baseID == resourceId){
//				resource.UseResources (amount); 
//			}
//		}
//
//	}
//
//
//
//	// For testing only.
//	public void useOneWood() {
//		useResource ("wood", 1);
//	}
//
//	public void useFiveWood() {
//		useResource ("wood", 5);
//	}

}

public enum ResourceType {
	iron,
	wood,
	herbs,
	cotton,
}