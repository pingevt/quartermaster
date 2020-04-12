using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingController : MonoBehaviour {

	public GameObject UIPrefab;
	public Canvas canvas;

	public int spacing = 50;

	protected CraftingManager craftingManager;

	public Dictionary<int, GameObject> slotUIDict = new Dictionary<int, GameObject>();

	// Use this for initialization
	void Start () {
		craftingManager = FindObjectOfType<CraftingManager>();
		if (!craftingManager) {
			Debug.LogWarning ("No Crafting Manager");
		}
	}

	// Update is called once per frame
	void Update () {
		foreach (CraftingSlot slot in craftingManager.slots) {

			int index = craftingManager.slots.IndexOf (slot);

			if (slotUIDict.ContainsKey (index)) {
//				UpdateSlotUI (index, slot);
			} else {
				AddSlotUI (index, slot);
			}
		}
	}

	void AddSlotUI(int index, CraftingSlot slot) {
		GameObject button = Instantiate(UIPrefab, new Vector3 (0f, 0f, 0f), canvas.transform.rotation) as GameObject;
		button.transform.SetParent (canvas.transform);

		RectTransform rt = button.GetComponent<RectTransform> ();

		Vector3 newPos = new Vector3 ((spacing * slotUIDict.Count), 0f, 0f);
		rt.anchoredPosition = newPos;

		button.GetComponent<CraftingSlotElementUI>().SetSlot (slot);

		slotUIDict.Add (index, button);
	}

	public void ChangedCrafting(int index) {
    slotUIDict[index].GetComponent<CraftingSlotElementUI>().SetInactive();
    slotUIDict[index].GetComponent<CraftingSlotElementUI>().SetActive();
  }

	public void FinishedCrafting(int index) {
		if (slotUIDict.ContainsKey(index))
			slotUIDict[index].GetComponent<CraftingSlotElementUI>().SetInactive();
	}

}
