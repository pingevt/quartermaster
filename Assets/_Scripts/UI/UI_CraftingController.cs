using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingController : MonoBehaviour {

	public GameObject UIPrefab;
	public Canvas canvas;

	public int spacing = 50;

	protected CraftingManager craftingManager;

	public Dictionary<string, GameObject> slotUIDict = new Dictionary<string, GameObject>();

	// Use this for initialization
	void Start () {
		craftingManager = FindObjectOfType<CraftingManager>();
		if (!craftingManager) {
			Debug.LogWarning ("No Crafting Manager");
		}
	}

	// Update is called once per frame
	void Update () {
		foreach (KeyValuePair<string, GameObject> slotGO in craftingManager.craftingSlotsDict) {

			if (slotUIDict.ContainsKey (slotGO.Key)) {
//				UpdateSlotUI (index, slot);
			} else {
				AddSlotUI (slotGO.Key, slotGO.Value);
			}
		}
	}

	void AddSlotUI(string slot_id, GameObject slotGO) {

		CraftingSlot slot = slotGO.GetComponent<CraftingSlot> ();
		
		GameObject button = Instantiate(UIPrefab, new Vector3 (0f, 0f, 0f), canvas.transform.rotation) as GameObject;
		button.transform.SetParent (canvas.transform);

		RectTransform rt = button.GetComponent<RectTransform> ();

		Vector3 newPos = new Vector3 ((spacing * slotUIDict.Count), 0f, 0f);
		rt.anchoredPosition = newPos;

		button.GetComponent<CraftingSlotElementUI>().SetSlot (slot);

		slotUIDict.Add (slot_id, button);

	}

	public void ChangedCrafting(string index) {
		slotUIDict[index].GetComponent<CraftingSlotElementUI>().SetInactive();
		slotUIDict[index].GetComponent<CraftingSlotElementUI>().SetActive();
	}

	public void FinishedCrafting(string index) {
		if (slotUIDict.ContainsKey(index))
			slotUIDict[index].GetComponent<CraftingSlotElementUI>().SetInactive();
	}

}
