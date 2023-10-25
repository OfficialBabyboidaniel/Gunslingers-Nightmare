using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteDebugToFile : MonoBehaviour
{
    string filename = "";
    private int playsession = 0;

    private void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    // Start is called before the first frame update
    void Start()
    {
        filename = "Assets/Logs/LogFile.txt";
        playsession = PlayerPrefs.GetInt("PlaySession", 0);
        IncrementPlaySession(); // Increment playsession when the game starts
    }

    private void IncrementPlaySession()
    {
        playsession++;
        PlayerPrefs.SetInt("PlaySession", playsession);
        PlayerPrefs.Save(); // Save PlayerPrefs data
    }

    public void Log(string logString, string stackTrace, LogType type)
    {
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("playsession: " + playsession + ", date & time: " + System.DateTime.Now + ", " + logString);
        tw.Close();
    }
}

