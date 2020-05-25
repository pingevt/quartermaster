//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using System;
//
//[CustomEditor (typeof(BaseProvider), true ), CanEditMultipleObjects]
//public class BaseProviderEditor : Editor {
//
////	private SerializedProperty m_Requirements;
//
//	private void OnEnable ()
//	{
////		m_Requirements = serializedObject.FindProperty ("requirements");
//	}
//
//	public override void OnInspectorGUI() {
//		DrawDefaultInspector ();
//
//		EditorGUILayout.Space();
//		EditorGUILayout.Space();
////		GUILayout.Label("Add Requirement");
////
////		serializedObject.Update ();
////
////		if(GUILayout.Button("Add Building Level Requirement")) {
////			BaseProvider script = (BaseProvider)target;
////			script.addBuildLvlReq(3);
////		}
//
//		serializedObject.ApplyModifiedProperties ();
//
//	}
//}