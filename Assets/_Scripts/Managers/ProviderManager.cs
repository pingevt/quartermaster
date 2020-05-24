using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProviderManager : MonoBehaviour {

	public ResourceManager resourceManager;
	public RecipeManager recipeManager;
	public CraftingManager craftingManager;
	public BuildingManager buildingManager;
	public WarehouseManager warehouseManager;

	public void CheckProviders(GameObject item) {

		ResourceProvider[] rProviders = item.GetComponents<ResourceProvider> ();
		if (rProviders.Length >= 1) {
			foreach (ResourceProvider rp in rProviders) {
				resourceManager.ProvideResources (rp);
			}
		}

		CraftSlotProvider[] csProviders = item.GetComponents<CraftSlotProvider> ();
		if (csProviders.Length >= 1) {
			foreach (CraftSlotProvider csp in csProviders) {
				craftingManager.ProvideCraftSlots (csp);
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
