using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public List<GameObject> availableBuildings;
    public Dictionary<int, GameObject> availableBuildingsDict = new Dictionary<int, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject b in availableBuildings) {

            availableBuildingsDict.Add(availableBuildings.IndexOf(b), b);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void buildBuilding(string buildingID) {
		
	}
}
