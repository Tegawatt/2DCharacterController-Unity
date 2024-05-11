using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ContCustomEditorWidnow : ExtendedEditorWindow
{
    public static void Open(Controller dataObject)
    {
        ContCustomEditorWidnow window = GetWindow<ContCustomEditorWidnow>("Controller Editor");
        window.serializedObject = new SerializedObject(dataObject);
    }

    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("Controller");
        DrawProperties(currentProperty, true);
    }
}
