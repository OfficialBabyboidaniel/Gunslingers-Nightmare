using System.Collections;
using System.Collections.Generic;
using SteamAudio;
using System.IO;
using UnityEngine;
using System;

public class JSONReader : MonoBehaviour
{
    // Start is called before the first frame update
    private TextAsset JSONText;
    //string filePath = "JSONText.txt";
    public GameObject PlayerInGame;

    public List<GameObject> Enemys = new List<GameObject>();

    public GameObject DialogueSource;
    public GameObject WallSource;


    [System.Serializable]
    public class Player
    {
        public float TimeBetweenFiring;
    }

    [System.Serializable]
    public class Enemy
    {
        public int EnemyAttackDmg;
        public float EnemyAttackDelay;
        public float EnemyMovementSpeed;
    }

    [System.Serializable]
    public class Level
    {
        public bool ContinueWallHitSound;
        public bool ShouldWallPlaySound;
        public float DialogueVolume;
        public float WallVolume;
    }

    [System.Serializable]
    public class Datas
    {
        public Player[] player;
        public Enemy[] enemy;
        public Level[] level;
    }

    public Datas datas = new Datas();

    void Start()
    {

        LoadTextFileIntoTextAssetMethod("JSONText.txt", "Build");
        datas = JsonUtility.FromJson<Datas>(JSONText.text);
        PlayerInGame.GetComponent<PlayerStats>().timeBetweenFiring = datas.player[0].TimeBetweenFiring;

        foreach (GameObject ai in Enemys)
        {
            if (ai != null)
            {
                ai.GetComponent<AIStats>().attackCooldown = datas.enemy[0].EnemyAttackDelay;
                ai.GetComponent<AIStats>().HitDamage = datas.enemy[0].EnemyAttackDmg;
                ai.GetComponent<AIStats>().speed = datas.enemy[0].EnemyMovementSpeed;
            }
        }

        if (DialogueSource != null)
        {
            DialogueSource.GetComponent<AudioSource>().volume = datas.level[0].DialogueVolume;
        }
        if (WallSource != null)
        {
            WallSource.GetComponent<AudioSource>().volume = datas.level[0].WallVolume;
        }

        PlayerInGame.GetComponent<PlayerHitWall>().playSound = datas.level[0].ShouldWallPlaySound;
        PlayerInGame.GetComponent<PlayerHitWall>().playSoundContinues = datas.level[0].ContinueWallHitSound;
    }

    void LoadTextFileIntoTextAssetMethod(string fileName, string folderPath)
    {
        try
        {
            // Use Path.Combine to create the full path
            string fullPath = Path.GetFullPath("../Build/JSONText.txt");

            // Debug.Log("correct file path: " + "C:\Users\danie\OneDrive\Documents\GitHub\Gunslingers-Nightmare\Gunslingers Nightmare\Build");
            if (File.Exists(fullPath))
            {
                string fileContent = File.ReadAllText(fullPath);
                // ... rest of your code
                JSONText = new TextAsset(fileContent);
            }
            else
            {
                Debug.LogError("File not found at path: " + fullPath);
            }

            // Create a new TextAsset and assign the file content

            // Debug.Log("TextAsset loaded from file: " + fullPath);
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading TextAsset from file: " + e.Message);
        }
    }

}
