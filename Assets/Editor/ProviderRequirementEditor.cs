//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using System;
//
//[CustomPropertyDrawer (typeof(ProviderRequirement))]
//public class ProviderRequirementEditor : PropertyDrawer {
//
//	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
//
//		EditorGUI.BeginProperty(position, label, property);
//
//		// Draw label
//		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
//
//		// Don't make child fields be indented
//		var indent = EditorGUI.indentLevel;
//		EditorGUI.indentLevel = 0;
//
//
//		// Set indent back to what it was
//		EditorGUI.indentLevel = indent;
//
//		EditorGUI.EndProperty();
//
//	}
//}
//
//[CustomPropertyDrawer (typeof(ProvReqBuildingLevel), true)]
//public class ProvReqBuildingLevelEditor : PropertyDrawer {
//	
//	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
//		EditorGUI.BeginProperty(position, label, property);
//		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
//
//		// Don't make child fields be indented
////		var indent = EditorGUI.indentLevel;
////		EditorGUI.indentLevel = 0;
//
//
//		var levelRect = new Rect(position.x, position.y, 50, position.height);
//
//		EditorGUI.PropertyField(levelRect, property.FindPropertyRelative("level"), GUIContent.none);
//
//		// Set indent back to what it was
////		EditorGUI.indentLevel = indent;
//
//		EditorGUI.EndProperty();
//	}
//}