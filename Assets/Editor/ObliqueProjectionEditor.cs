using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ObliqueProjection))]
public class ObliqueProjectionEditor : Editor
{
    public override void OnInspectorGUI ()
    {
        var t = target as ObliqueProjection;

        GUI.changed = false;
        t.angle = EditorGUILayout.Slider ("Angle", t.angle, -180.0f, 180.0f);
        t.zScale = EditorGUILayout.Slider ("Z Scale", t.zScale, 0.0f, 1.0f);
        t.zOffset = EditorGUILayout.FloatField ("Z Offset", t.zOffset);

        if (GUI.changed) {
            EditorUtility.SetDirty (target);
            t.Apply ();
        }
    }
}