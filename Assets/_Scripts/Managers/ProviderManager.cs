using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProviderManager : MonoBehaviour {

	public ResourceManager resourceManager;
	public BuildingManager buildingManager;



	public void CheckProviders(GameObject item) {

		ResourceProvider[] rProviders = item.GetComponents<ResourceProvider> ();
		if (rProviders.Length >= 1) {
			foreach (ResourceProvider rp in rProviders) {
				resourceManager.ProvideResources (rp);
			}
		}

		BuildingProvider[] bProviders = item.GetComponents<BuildingProvider> ();
		if (bProviders.Length >= 1) {
			foreach (BuildingProvider bp in bProviders) {
				buildingManager.ProvideBuildings (bp);
			}
		}
	}
}
