using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;

[CustomEditor (typeof(BuildingManager))]
public class BuildingManagerEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector ();

		EditorGUILayout.Space();
		GUILayout.Label("Dictionaries:");

		if (Application.isPlaying) {

			BuildingManager script = (BuildingManager)target;

			// Available.
			EditorGUILayout.Space();
			GUILayout.Label("Available Buildings");
			foreach(KeyValuePair<string, GameObject> kvp in script.availableBlueprintsDict) {
				GUILayout.Label("Building: " + kvp.Key);
			}

			// Buildable.
			EditorGUILayout.Space();
			GUILayout.Label("Buildable Buildings");
			foreach(KeyValuePair<string, GameObject> kvp in script.buildableBlueprintsDict) {
				GUILayout.Label("Building: " + kvp.Key);
			}

			// Build Count.
			EditorGUILayout.Space();
			GUILayout.Label("Buildings Build Count");
			foreach(KeyValuePair<string, int> kvp in script.buildingCount) {
				GUILayout.BeginHorizontal();
				GUILayout.Label ("Building: " + kvp.Key, GUILayout.Width(180));
				GUILayout.Label ("Count: " + kvp.Value.ToString(), GUILayout.Width(200));
				GUILayout.EndHorizontal();
			}
		}
	}
}
