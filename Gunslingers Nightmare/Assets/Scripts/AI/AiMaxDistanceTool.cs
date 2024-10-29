using System.Collections;
using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;

// This script is a custom editor tool for the AIStats component.
// It allows you to visually edit the MaxSightRange property of AIStats in the Scene view.

// [CustomEditor(typeof(AIStats))]
// public class AiMaxDistanceTool : Editor
// {
//     // This method is called to draw the custom GUI in the Scene view
//     private void OnSceneGUI()
//     {
//         // Get a reference to the AIStats component
//         AIStats aiStats = (AIStats)target;
//         if (aiStats == null)
//             return;

//         // Set the color for the wire disc to red
//         Handles.color = Color.red;
//         // Draw a wire disc at the AI's position with a radius of MaxSightRange
//         Handles.DrawWireDisc(aiStats.transform.position, Vector3.back, aiStats.MaxSightRange);

//         // Begin checking for changes in the GUI
//         EditorGUI.BeginChangeCheck();
//         // Create a radius handle to allow the user to change the MaxSightRange
//         float newSightRange = Handles.RadiusHandle(Quaternion.identity, aiStats.transform.position, aiStats.MaxSightRange);

//         // If the user has changed the MaxSightRange
//         if (EditorGUI.EndChangeCheck())
//         {
//             // Ensure the sight range is not negative
//             newSightRange = Mathf.Max(0, newSightRange);
//             // Update the MaxSightRange property of AIStats
//             aiStats.MaxSightRange = newSightRange;
//             // Mark the AIStats object as dirty to ensure the change is saved
//             EditorUtility.SetDirty(aiStats);
//         }
//     }
// }