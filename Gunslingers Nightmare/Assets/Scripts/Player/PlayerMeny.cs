using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Manages the player menu UI, game pause state, and player/AI parameter modifications.
public class PlayerMeny : MonoBehaviour
{
    // Reference to the canvas GameObject that represents the in-game menu.
    public GameObject canvas;
    
    // Reference to the audio listener that can be enabled/disabled with the menu.
    public AudioListener audioListener;
    
    // Tracks the current state of the game (paused or not).
    private bool isGamePaused = false;

    // Reference point for player rotation control and shooting behavior.
    public GameObject RotatePoint;
    
    // Reference to the parameter panel UI for modifying settings.
    public GameObject ParameterPanel;
    
    // UI input fields for enemy and player parameters.
    public TMP_InputField EnemyAttackDmg;
    public TMP_InputField EnemyAttackDelay;
    public TMP_InputField PlayerShootDelay;
    public TMP_InputField EnemyMovementSpeed;

    // List of active AI enemies in the scene.
    public List<GameObject> AIEnemies = new List<GameObject>();

    // Cached references to player and AI stats for modifying parameters.
    private PlayerStats playerStats;
    private AIStats aiStats;

    // Update is called once per frame to handle pause functionality.
    void Update()
    {
        // Check if the Escape or P key is pressed to toggle the game pause state.
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!isGamePaused)
            {
                // Pause the game and activate the menu UI.
                Time.timeScale = 0;
                canvas.SetActive(true);
                isGamePaused = true;
                
                // Disable audio and player shooting when paused.
                audioListener.enabled = false;
                RotatePoint.GetComponent<Shooting>().enabled = false;
            }
            else
            {
                // Unpause the game and deactivate the menu UI.
                Time.timeScale = 1;
                canvas.SetActive(false);
                isGamePaused = false;
                
                // Re-enable audio and player shooting, and hide parameter panel.
                audioListener.enabled = true;
                RotatePoint.GetComponent<Shooting>().enabled = true;
                ParameterPanel.SetActive(false);
            }
        }
    }

    // Resumes the game by hiding the menu UI and re-enabling game components.
    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        isGamePaused = false;
        audioListener.enabled = true;
        RotatePoint.GetComponent<Shooting>().enabled = true;
        ParameterPanel.SetActive(false);
    }

    // Shows the parameter panel and populates it with current player and AI stats.
    public void Parameters()
    {
        ParameterPanel.SetActive(true);
        
        // Retrieve and display player shooting delay.
        playerStats = GetComponent<PlayerStats>();
        PlayerShootDelay.text = playerStats.timeBetweenFiring.ToString();
        
        // If AI enemies exist, retrieve and display their stats.
        if (AIEnemies.Count > 0)
        {
            aiStats = AIEnemies[0].GetComponent<AIStats>();
            EnemyAttackDmg.text = aiStats.HitDamage.ToString();
            EnemyAttackDelay.text = aiStats.attackCooldown.ToString();
            EnemyMovementSpeed.text = aiStats.speed.ToString();
        }
    }

    // Hides the parameter panel, returning to the main menu.
    public void BackToMeny()
    {
        ParameterPanel.SetActive(false);
    }

    // Updates the relevant parameter based on which input field was changed.
    public void OnInputChanged(TMP_InputField inputField)
    {
        // Gets the input value as a string and assigns it to the relevant handler.
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

    // Helper function to update the enemy attack damage across all AI enemies.
    private void HitDamageChange(string value)
    {
        if (float.TryParse(value, out float newAttackDmg))
        {
            // Iterate through each AI enemy and update their attack damage.
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
            // Handle invalid input if needed (e.g., display an error message).
        }
    }

    // Helper function to update the enemy attack delay across all AI enemies.
    private void AttackDelayChange(string value)
    {
        if (float.TryParse(value, out float newAttackDelay))
        {
            // Iterate through each AI enemy and update their attack delay.
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
            // Handle invalid input if needed.
        }
    }

    // Helper function to update the enemy movement speed across all AI enemies.
    private void MovementSpeedChange(string value)
    {
        if (float.TryParse(value, out float newMovementSpeed))
        {
            // Iterate through each AI enemy and update their movement speed.
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
            // Handle invalid input if needed.
        }
    }

    // Helper function to update the player shooting delay.
    private void PlayerShootDelayChange(string value)
    {
        if (float.TryParse(value, out float newPlayerShootDelay))
        {
            // Update the player's shooting delay stat.
            playerStats.timeBetweenFiring = newPlayerShootDelay;
        }
        else
        {
            // Handle invalid input if needed.
        }
    }
}
