using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BuildingsController : MonoBehaviour
    {
    public GameObject UIPrefab;
    public GameObject UIScrollerPrefab;
    protected GameObject UIScroller;
    public Canvas canvas;

    private BuildingManager buildingManager;


    public Dictionary<int, GameObject> buildingUIDict = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start() {
        buildingManager = GetComponent<BuildingManager>();

        // Instantiate Scroll View.
        UIScroller = Instantiate(UIScrollerPrefab, UIScrollerPrefab.transform.position, UIScrollerPrefab.transform.rotation) as GameObject;
        UIScroller.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update() {
        foreach (KeyValuePair<int, GameObject> building in buildingManager.availableBuildingsDict) {
            if (buildingUIDict.ContainsKey(building.Key)) {
                // Nothing at the moment.
            }
            else {
                AddBuildingButton(building.Key, building.Value);
            }
        }
    }

    private void AddBuildingButton (int index, GameObject building) {

        Debug.Log(UIScroller.transform.GetChild(0));
        Debug.Log(UIScroller.transform.GetChild(0).transform.GetChild(0));

        GameObject button = Instantiate(UIPrefab, UIPrefab.transform.position, UIPrefab.transform.rotation) as GameObject;
        button.transform.SetParent(UIScroller.transform.GetChild(0).transform.GetChild(0), false);



    // RectTransform rt = button.GetComponent<RectTransform>();

    // Vector3 newPos = new Vector3(0f, (recipeSpacing * recipeUIDict.Count), 0f);
    // rt.anchoredPosition = newPos;

        buildingUIDict.Add(index, button);

    // // Set Image.
    // Sprite sp = resource.GetComponent<Recipe>().recipeImage;
    // button.GetComponent<RecipeElementUI>().SetSprite(sp);

    // // Set Button
    // resource.GetComponent<Recipe>().AddButton(button.GetComponentInChildren<Button>());
    }
}
