using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerMeny : MonoBehaviour
{
    public GameObject canvas;
    public AudioListener audioListener;
    private bool isGamePaused = false;

    public GameObject RotatePoint;

    public GameObject ParameterPanel;

    public TMP_InputField EnemyAttackDmg;


    public TMP_InputField EnemyAttackDelay;
    public TMP_InputField PlayerShootDelay;
    public TMP_InputField EnemyMovementSpeed;

    public List<GameObject> AIEnemies = new List<GameObject>();

    private PlayerStats playerStats;

    private AIStats aiStats;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!isGamePaused)
            {
                // Pause the game and activate the menu
                Time.timeScale = 0;
                canvas.SetActive(true);
                isGamePaused = true;
                audioListener.enabled = false;
                RotatePoint.GetComponent<Shooting>().enabled = false;
            }
            else
            {
                // Unpause the game and deactivate the menu
                Time.timeScale = 1;
                canvas.SetActive(false);
                isGamePaused = false;
                audioListener.enabled = true;
                RotatePoint.GetComponent<Shooting>().enabled = true;
                ParameterPanel.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        isGamePaused = false;
        audioListener.enabled = true;
        RotatePoint.GetComponent<Shooting>().enabled = true;
        ParameterPanel.SetActive(false);
    }

    public void Parameters()
    {
        ParameterPanel.SetActive(true);
        playerStats = GetComponent<PlayerStats>();
        PlayerShootDelay.text = playerStats.timeBetweenFiring.ToString();
        if (AIEnemies.Count > 0)
        {
            aiStats = AIEnemies[0].GetComponent<AIStats>();
            EnemyAttackDmg.text = aiStats.HitDamage.ToString();
            EnemyAttackDelay.text = aiStats.attackCooldown.ToString();
            EnemyMovementSpeed.text = aiStats.speed.ToString();

        }
    }

    public void BackToMeny()
    {
        ParameterPanel.SetActive(false);
    }

    public void OnInputChanged(TMP_InputField inputField)
    {
        string value = inputField.text;
        if (inputField.name == "EnemyAttackDmg")
        {
            HitDamageChange(value);
        }
        if (inputField.name == "EnemyAttackDelay")
        {
            AttackDelayChange(value);
        }
        if (inputField.name == "EnemyMovementSpeed")
        {
            MovementSpeedChange(value);
        }

        if (inputField.name == "PlayerShootDelay")
        {
            PlayerShootDelayChange(value);
        }
    }

    //helper functions
    private void HitDamageChange(string value)
    {
        if (float.TryParse(value, out float newAttackDmg))
        {
            // Loop through all AI enemies and update their attack damage.
            foreach (GameObject ai in AIEnemies)
            {
                if (ai != null)
                {
                    ai.GetComponent<AIStats>().HitDamage = (int)newAttackDmg;
                }
            }
        }
        else
        {
            // You may want to display an error message or take appropriate action.
        }
    }
    private void AttackDelayChange(string value)
    {
        if (float.TryParse(value, out float newAttackDelay))
        {
            // Loop through all AI enemies and update their attack delay.
            foreach (GameObject ai in AIEnemies)
            {
                if (ai != null)
                {
                    ai.GetComponent<AIStats>().attackCooldown = newAttackDelay;
                }
            }
        }
        else
        {
            // Handle invalid input (non-numeric value).
            // You may want to display an error message or take appropriate action.
        }
    }

    private void MovementSpeedChange(string value)
    {
        if (float.TryParse(value, out float newMovementSpeed))
        {
            // Loop through all AI enemies and update their movement speed.
            foreach (GameObject ai in AIEnemies)
            {
                if (ai != null)
                {
                    ai.GetComponent<AIStats>().speed = newMovementSpeed;
                }
            }
        }
        else
        {
            // Handle invalid input (non-numeric value).
            // You may want to display an error message or take appropriate action.
        }
    }
    private void PlayerShootDelayChange(string value)
    {
        if (float.TryParse(value, out float newPlayerShootDelay))
        {
            playerStats.timeBetweenFiring = newPlayerShootDelay;
        }
        else
        {
            // Handle invalid input (non-numeric value).
            // You may want to display an error message or take appropriate action.
        }
    }

}


