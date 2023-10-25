using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset JSONText;

    public GameObject PlayerInGame;

    public List<GameObject> Enemys = new List<GameObject>();

    public GameObject DialogueSource = null;
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
