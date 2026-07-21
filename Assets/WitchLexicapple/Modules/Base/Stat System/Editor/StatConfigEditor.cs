using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MysticalDreamers.WitchLexicapple
{
    [CustomEditor(typeof(StatConfig))]
    public class StatConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var statsListProp = serializedObject.FindProperty("stats");

            if (statsListProp == null)
                return;

            var statsProp = statsListProp.FindPropertyRelative("stats");

            if (statsProp == null)
                return;

            SyncKeys(statsProp);

            EditorGUILayout.LabelField("Default Stats", EditorStyles.boldLabel);

            var keys = (StatKey[])Enum.GetValues(typeof(StatKey));
            var groups = keys.GroupBy(StatKeyUtility.GetGroup);

            foreach (var group in groups)
            {
                EditorGUILayout.Space(4);
                EditorGUILayout.LabelField(group.Key, EditorStyles.boldLabel);

                EditorGUILayout.BeginVertical(GUI.skin.box);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Key", EditorStyles.miniBoldLabel, GUILayout.Width(90));
                EditorGUILayout.LabelField("Label", EditorStyles.miniBoldLabel, GUILayout.Width(150));
                EditorGUILayout.LabelField("Value", EditorStyles.miniBoldLabel);
                EditorGUILayout.EndHorizontal();

                foreach (var key in group)
                {
                    var element = FindElement(statsProp, StatList.ToKeyString(key));

                    if (element == null)
                        continue;

                    var keyProp = element.FindPropertyRelative("key");
                    var labelProp = element.FindPropertyRelative("label");
                    var valueProp = element.FindPropertyRelative("value");

                    EditorGUILayout.BeginHorizontal();

                    using (new EditorGUI.DisabledScope(true))
                    {
                        EditorGUILayout.TextField(keyProp.stringValue, GUILayout.Width(90));
                    }

                    EditorGUILayout.PropertyField(labelProp, GUIContent.none, GUILayout.Width(150));
                    EditorGUILayout.PropertyField(valueProp, GUIContent.none);

                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndVertical();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private static SerializedProperty FindElement(SerializedProperty statsProp, string keyString)
        {
            for (int i = 0; i < statsProp.arraySize; i++)
            {
                var element = statsProp.GetArrayElementAtIndex(i);

                if (element.FindPropertyRelative("key").stringValue == keyString)
                    return element;
            }

            return null;
        }

        private static void SyncKeys(SerializedProperty statsProp)
        {
            var keys = (StatKey[])Enum.GetValues(typeof(StatKey));

            foreach (var key in keys)
            {
                var keyString = StatList.ToKeyString(key);
                var found = false;

                for (int i = 0; i < statsProp.arraySize; i++)
                {
                    if (statsProp.GetArrayElementAtIndex(i).FindPropertyRelative("key").stringValue == keyString)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    statsProp.arraySize++;
                    var element = statsProp.GetArrayElementAtIndex(statsProp.arraySize - 1);
                    element.FindPropertyRelative("key").stringValue = keyString;
                    element.FindPropertyRelative("label").stringValue = StatKeyDefaults.GetDefaultLabel(key);
                    element.FindPropertyRelative("value").floatValue = StatKeyDefaults.GetDefaultValue(key);
                }
            }

            for (int i = statsProp.arraySize - 1; i >= 0; i--)
            {
                var keyValue = statsProp.GetArrayElementAtIndex(i).FindPropertyRelative("key").stringValue;
                var stillValid = false;

                foreach (var key in keys)
                {
                    if (StatList.ToKeyString(key) == keyValue)
                    {
                        stillValid = true;
                        break;
                    }
                }

                if (!stillValid)
                    statsProp.DeleteArrayElementAtIndex(i);
            }
        }
    }
}
