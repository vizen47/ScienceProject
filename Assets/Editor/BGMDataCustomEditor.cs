using KDH.Scripts.Sounds;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(BGMSoundDataSO))]
    public class BGMDataCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("audioClip"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("startTime"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("loop"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("volume"));
            var randomPitch = serializedObject.FindProperty("randomPitch");
            EditorGUILayout.PropertyField(randomPitch, new GUIContent("randomPitch"));
            
            if (randomPitch.boolValue)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("minPitch"), new GUIContent("minPitchSetter"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("maxPitch"), new GUIContent("maxPitchSetter"));
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}