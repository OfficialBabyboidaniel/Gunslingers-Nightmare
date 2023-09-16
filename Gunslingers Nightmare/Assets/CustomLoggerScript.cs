using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomLoggerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private string logFilePath = "log.txt";

    private void Start()
    {
        // Delete the previous log file (optional)
        if (File.Exists(logFilePath))
        {
            File.Delete(logFilePath);
        }
    }

    public void Log(string message)
    {
        Debug.Log(message); // Log to Unity Console (optional)

        // Write to a text file
        using (StreamWriter writer = File.AppendText(logFilePath))
        {
            writer.WriteLine(message);
        }
    }
}
