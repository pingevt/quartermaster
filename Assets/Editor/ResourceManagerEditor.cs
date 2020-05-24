using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor (typeof(ResourceManager))]
public class ResourceManagerEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector ();

		if (Application.isPlaying) {

			ResourceManager script = (ResourceManager)target;
	
			foreach(KeyValuePair<string, GameObject> entry in script.resourceDict) {

				// Available.
				EditorGUILayout.Space();
				GUILayout.Label("Available Resources");

				foreach(KeyValuePair<string, GameObject> kvp in script.resourceDict) {
					GUILayout.Label("Resource: " + kvp.Key);
				}

//				if (GUILayout.Button("Consume 1 " + entry.Key.ToString(), GUILayout.Width(150))) {
//					script.ConsumeResource (entry.Key, 1);
//				}
//				if (GUILayout.Button("Consume 5 " + entry.Key.ToString(), GUILayout.Width(150))) {
//					script.ConsumeResource (entry.Key, 5);
//				} 
			}
		}
	}
}
