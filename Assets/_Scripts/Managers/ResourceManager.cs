using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	public GameObject[] renewableResources;
	public GameObject[] gatherableResources;
  	public GameObject[] collectableResources;

	public Dictionary<string, GameObject> resourceDict = new Dictionary<string, GameObject>();

	// Use this for initialization
	void Start () {
		foreach (GameObject resource in renewableResources) {
			GameObject go = Instantiate(resource, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;

			resourceDict.Add (go.GetComponent<BaseResource>().resourceId, go);
		}

		foreach (GameObject resource in gatherableResources) {
			GameObject go = Instantiate(resource, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;

			resourceDict.Add (go.GetComponent<BaseResource>().resourceId, go);
		}

		foreach (GameObject resource in collectableResources) {
			GameObject go = Instantiate(resource, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;

			resourceDict.Add (go.GetComponent<BaseResource>().resourceId, go);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public bool AvailableResources(List<ResourceNeed> resources) {
		bool avail = true;

		foreach (ResourceNeed need in resources) {
			if (!resourceDict [need.resourceID].GetComponent<BaseResource>().CheckAvailable (need.count)) {
				avail = false;
			}
		}

		return avail;
	}

	public bool ConsumeResources(List<ResourceNeed> resources) {

		foreach (ResourceNeed need in resources) {
			ConsumeResource(need.resourceID, need.count);
		}

		return true;
	}

	public void ConsumeResource(string resource_id, int count) {

		resourceDict [resource_id].GetComponent<BaseResource> ().UseResources (count);
	}

	public bool ProvideResource(GameObject resourceGO) {
		BaseResource resource = resourceGO.GetComponent<BaseResource> ();

		// Check if it is a blueprint.
		if (resource == null) {
			Debug.LogWarning ("No resource");
			return false;
		}

		// Check if already available. 
		if (resourceDict.ContainsKey (resource.resourceId)) {
			Debug.LogWarning ("Already in the system");
			return false;
		}

		// Instantiate and add to list.
		GameObject go = Instantiate(resourceGO, transform.position, transform.rotation) as GameObject;
		go.transform.parent = transform;

		resourceDict.Add (go.GetComponent<BaseResource>().resourceId, go);

		return true; 
	}


	public bool ProvideResources(ResourceProvider rp) {

		foreach (GameObject resource in rp.objects) {
			ProvideResource (resource);
		}

		return true;
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

//public enum ResourceType {
//	iron,
//	wood,
//	herbs,
//	cotton,
//	rock,
//}
