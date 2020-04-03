using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(CraftingManager))]
public class CraftingManagerEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector ();

		if (Application.isPlaying) {
			EditorGUILayout.Space();
			EditorGUILayout.Space(); 

			CraftingManager script = (CraftingManager)target;

			if (GUILayout.Button("Add Crafting Slot", GUILayout.Width(150))) {
				script.AddCraftingSlot ();
			}
		}
	}
}