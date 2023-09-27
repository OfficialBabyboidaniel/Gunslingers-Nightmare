using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [CustomEditor(typeof(AIChase))]
// public class AiMaxDistanceTool : Editor
// {
//     private void OnSceneGUI()
//     {
//         AIChase aiChase = (AIChase)target;
//         Handles.color = Color.red;
//         Handles.DrawWireDisc(aiChase.transform.position, Vector3.back, aiChase.MaxSightRange);

//         EditorGUI.BeginChangeCheck();
//         float newSightRange = Handles.RadiusHandle(Quaternion.identity, aiChase.transform.position, aiChase.MaxSightRange);

//         if (EditorGUI.EndChangeCheck())
//         {
//             // Ensure the sight range is not negative
//             newSightRange = Mathf.Max(0, newSightRange);
//             aiChase.MaxSightRange = newSightRange;
//             EditorUtility.SetDirty(aiChase);
//         }
//     }
// }
