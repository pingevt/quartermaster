using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BaseBuilding : MonoBehaviour
{
    public int lvl = 1;
    public int exp = 0;

	private Blueprint blueprint;
	private BuildingExpLevels experienceLevels = new BuildingExpLevels ();
	private ProviderManager providerManager;

  // Start is called before the first frame update
    void Start()
	{
		providerManager = FindObjectOfType<ProviderManager>();
		if (!providerManager) {
			Debug.LogWarning ("No providerManager");
		}
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void AddExperience(int exp_amount) {
		exp += exp_amount;
		int expLvl = experienceLevels.returnLevel (exp);

		if (expLvl > lvl) {
			LevelUp ();
		}
	}

	public void LevelUp() {
		lvl++;

		// Submit for providers
		providerManager.CheckProviders (gameObject);

	}
}
