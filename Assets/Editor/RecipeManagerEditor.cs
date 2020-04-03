using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(RecipeManager))]
public class RecipeManagerEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector ();

		if (Application.isPlaying) {
			EditorGUILayout.Space();
			EditorGUILayout.Space(); 

			RecipeManager script = (RecipeManager)target;

			if (GUILayout.Button("Queue Sword", GUILayout.Width(150))) {
				script.queueSword ();
			}
			if (GUILayout.Button("Queue Staff", GUILayout.Width(150))) {
				script.queueStaff ();
			}
		}
	}
}