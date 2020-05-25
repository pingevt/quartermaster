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

		Debug.Log ("START" + item.name.ToString());

//		Debug.Log ("Resource Providers:");
		ResourceProvider[] rProviders = item.GetComponents<ResourceProvider> ();
//		Debug.Log ("Count: " + rProviders.Length.ToString());
		if (rProviders.Length >= 1) {
			foreach (ResourceProvider rp in rProviders) {
//				Debug.Log (rp.isValid ());
				if (rp.isValid ()) {
					resourceManager.ProvideResources (rp, item);
				}
			}
		}

//		Debug.Log ("Recipe Providers:");
		RecipeProvider[] recProviders = item.GetComponents<RecipeProvider> ();
//		Debug.Log ("Count: " + recProviders.Length.ToString());
		if (recProviders.Length >= 1) {
			foreach (RecipeProvider recp in recProviders) {
				Debug.Log (recp.isValid ());
				if (recp.isValid ()) {
					recipeManager.ProvideRecipes (recp, item);
				}
			}
		}

//		Debug.Log ("Craft Slot Providers:");
		CraftSlotProvider[] csProviders = item.GetComponents<CraftSlotProvider> ();
//		Debug.Log ("Count: " + csProviders.Length.ToString());
		if (csProviders.Length >= 1) {
			foreach (CraftSlotProvider csp in csProviders) {
//				Debug.Log (csp.isValid ());
				if (csp.isValid ()) {
					craftingManager.ProvideCraftSlots (csp, item);
				}
			}
		}

		Debug.Log ("Building Providers:");
		BuildingProvider[] bProviders = item.GetComponents<BuildingProvider> ();
		Debug.Log ("Count: " + bProviders.Length.ToString());
		if (bProviders.Length >= 1) {
			foreach (BuildingProvider bp in bProviders) {
				Debug.Log ("Building Provider: " + bp.isValid ().ToString());
				if (bp.isValid ()) {
					buildingManager.ProvideBuildings (bp, item);
				}
			}
		}

//		Debug.Break ();
		Debug.Log ("END" + item.name.ToString());
	}
}
