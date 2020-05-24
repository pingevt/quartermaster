using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(CraftItem))]
public class CraftItemEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector ();

		if (Application.isPlaying) {
			EditorGUILayout.Space();
			EditorGUILayout.Space(); 

			CraftItem script = (CraftItem)target;

			if (GUILayout.Button("Sell Item", GUILayout.Width(150))) {
				script.sellItem ();
			}
		}
	}
}