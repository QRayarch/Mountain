using UnityEngine;  
using UnityEditor;  
using UnityEditorInternal;

[CustomEditor(typeof(Conversation))]
public class ConversationEditor : Editor  {

	private ReorderableList list;

	private void OnEnable() {
		list = new ReorderableList(serializedObject, serializedObject.FindProperty("dialogues"), true, false, true, true);
		list.drawElementCallback = DrawListElement;
	}

	private void DrawListElement(Rect rect, int index, bool isActive, bool isFocused) {
		SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);

		EditorGUI.PropertyField(new Rect(rect.x, rect.y, 200, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("text"), GUIContent.none);
		EditorGUI.PropertyField(new Rect(rect.x + 200, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("speaker"), GUIContent.none);
		EditorGUI.PropertyField(new Rect(rect.x + 282, rect.y, 40, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("duration"), GUIContent.none);
		EditorGUI.PropertyField(new Rect(rect.x + 326, rect.y, 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("sound"), GUIContent.none);
	}

	public override void OnInspectorGUI() {
		serializedObject.Update();
		list.DoLayoutList();
		serializedObject.ApplyModifiedProperties();
	}
}
