using System.Collections;
using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;

// [CustomEditor(typeof(AIStats))]
// public class AiMaxDistanceTool : Editor
// {
//     private void OnSceneGUI()
//     {
//         AIStats aiStats = (AIStats)target;
//         if (aiStats == null)
//             return;

//         Handles.color = Color.red;
//         Handles.DrawWireDisc(aiStats.transform.position, Vector3.back, aiStats.MaxSightRange);

//         EditorGUI.BeginChangeCheck();
//         float newSightRange = Handles.RadiusHandle(Quaternion.identity, aiStats.transform.position, aiStats.MaxSightRange);

//         if (EditorGUI.EndChangeCheck())
//         {
//             // Ensure the sight range is not negative
//             newSightRange = Mathf.Max(0, newSightRange);
//             aiStats.MaxSightRange = newSightRange;
//             EditorUtility.SetDirty(aiStats);
//         }
//     }
// }

