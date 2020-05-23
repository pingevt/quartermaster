using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor (typeof(UI_BuildingsController))]
public class UI_BuildingsControllerEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector ();

		EditorGUILayout.Space();
		GUILayout.Label("Dictionaries:");

		if (Application.isPlaying) {

			UI_BuildingsController script = (UI_BuildingsController)target;

			EditorGUILayout.Space();

			foreach(KeyValuePair<string, GameObject> kvp in script.buildingUIDict) {
				GUILayout.Label("Key: " + kvp.Key);
			}
		}
	}
}
