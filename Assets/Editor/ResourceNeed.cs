//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using System;
//
//[CustomPropertyDrawer (typeof(ResourceNeed))]
//public class ResourceNeedEditor : PropertyDrawer {
//
//	public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label) {
////		DrawDefaultInspector ();
//
//		SerializedProperty resourceID = prop.FindPropertyRelative ("resourceID");
//		SerializedProperty count = prop.FindPropertyRelative ("count");
//
//
//		Debug.Log (pos.width);
//		Debug.Log (label.ToString());
//		Debug.Log (pos.ToString());
////		EditorGUI.LabelField (new Rect (pos.x, pos.y, pos.width, pos.height), "BOB");
//
//		EditorGUI.PropertyField ( new Rect (pos.x, pos.y, 200f, pos.height), resourceID);
////		EditorGUI.PropertyField ( new Rect ((pos.x + (pos.width / 1.5f)), pos.y, (pos.width / 1.5f), pos.height), count);
//
//
//		EditorGUI.MultiPropertyField
//	}
//}
