using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;

[CustomEditor (typeof(CraftingManager))]
public class CraftingManagerEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector ();

		if (Application.isPlaying) {
			EditorGUILayout.Space();
			EditorGUILayout.Space(); 

			CraftingManager script = (CraftingManager)target;

			// Available.
			EditorGUILayout.Space();
			GUILayout.Label("Available Slots");
			foreach(KeyValuePair<string, GameObject> kvp in script.craftingSlotsDict) {
				GUILayout.Label("Slot: " + kvp.Key);
			}
		}
	}
}