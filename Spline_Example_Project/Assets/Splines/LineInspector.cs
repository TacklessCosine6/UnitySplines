#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Line))]
public class LineInspector : Editor {

    private void OnSceneGUI()
    {
        Line line = target as Line;
        Transform handleTransform = line.transform;
        Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        EditorGUI.BeginChangeCheck();
        Vector3 p0 = handleTransform.TransformPoint(line.p0);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(line, "Move Point");
            EditorUtility.SetDirty(line);
            line.p0 = handleTransform.InverseTransformPoint(p0);
        }

        EditorGUI.BeginChangeCheck();
        Vector3 p1 = handleTransform.TransformPoint(line.p1);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(line, "Move Point");
            EditorUtility.SetDirty(line);
            line.p1 = handleTransform.InverseTransformPoint(p1);
        }

        Handles.color = Color.white;
        Handles.DrawLine(p0, p1);
        Handles.DoPositionHandle(p0, handleRotation);
        Handles.DoPositionHandle(p1, handleRotation);
    }

}
#endif