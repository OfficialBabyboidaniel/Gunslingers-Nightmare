using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SoundController))]
public class SoundControllerMaxRangeTool : Editor
{
    private void OnSceneGUI()
    {
        SoundController soundController = (SoundController)target;
        if (soundController == null)
            return;

        Handles.color = Color.green;
        Handles.DrawWireDisc(soundController.transform.position, Vector3.back, soundController.maxDistance);

        EditorGUI.BeginChangeCheck();
        float newSightRange = Handles.RadiusHandle(Quaternion.identity, soundController.transform.position, soundController.maxDistance);

        if (EditorGUI.EndChangeCheck())
        {
            // Ensure the sight range is not negative
            newSightRange = Mathf.Max(0, newSightRange);
            soundController.maxDistance = newSightRange;
            EditorUtility.SetDirty(soundController);
        }
    }
}
