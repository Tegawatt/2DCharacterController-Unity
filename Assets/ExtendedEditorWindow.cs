using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExtendedEditorWindow : EditorWindow
{
   protected SerializedObject serializedObject;
   protected SerializedProperty currentProperty;
    
    protected void DrawProperties(SerializedProperty prop, bool drawChildren)
    {
        string lastPropPath = string.Empty;

        SerializedProperty iterator = serializedObject.GetIterator();

        drawChildren = true;
        iterator.NextVisible(drawChildren);
        drawChildren = false;

        do
        {
            serializedObject.Update();

            if (iterator.name == "speed")
            {
                SerializedProperty propSpeed = serializedObject.FindProperty("speed");
                EditorGUILayout.Slider(propSpeed, 1, 10);
            }

            if (iterator.name == "jump")
            {
                SerializedProperty propJump = serializedObject.FindProperty("jump");
                propJump.boolValue = EditorGUILayout.Toggle("Jump",propJump.boolValue);

                if (propJump.boolValue == true)
                {
                    SerializedProperty propJumpSpeed = serializedObject.FindProperty("jumpSpeed");
                    EditorGUILayout.Slider(propJumpSpeed, 1, 10);

                    SerializedProperty propJumpHeight = serializedObject.FindProperty("jumpHeight");
                    EditorGUILayout.Slider(propJumpHeight, 1, 10);
                }
            }

            if (iterator.name == "health")
            {
                SerializedProperty propHealth = serializedObject.FindProperty("health");
                propHealth.boolValue = EditorGUILayout.Toggle("Health", propHealth.boolValue);

                if (propHealth.boolValue == true)
                {
                    SerializedProperty propMaxHealth = serializedObject.FindProperty("maxHealth");
                    EditorGUILayout.IntSlider(propMaxHealth, 1, 10);
                }
            }

            serializedObject.ApplyModifiedProperties();
        } while (iterator.NextVisible(drawChildren));
        
    }
}
