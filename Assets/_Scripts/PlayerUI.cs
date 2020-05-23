using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public Player player;
	public Text goldAmountDisplay;

	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		goldAmountDisplay.text = player.monies.ToString ();
	}
}
