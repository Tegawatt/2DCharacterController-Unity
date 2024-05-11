using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        Controller controller = EditorUtility.InstanceIDToObject(instanceId) as Controller;
        if (controller != null)
        {
            ContCustomEditorWidnow.Open(controller);
            return true;
        }

        return false;
    }
}

[CustomEditor(typeof(Controller))]
public class ContCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Editor"))
        {
            ContCustomEditorWidnow.Open((Controller)target);
        }
    }
}
