using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIStats : MonoBehaviour
{
    // Speed of the AI character
    public float speed = 1;

    // Damage dealt by the AI character when it hits the player
    public int HitDamage = 4;

    // Cooldown time between attacks in seconds
    public float attackCooldown = 3f;

    // Maximum sight range of the AI character
    public float MaxSightRange = 10.0f;

    // Range within which the AI character can hit the player
    public float hitRange = 1.0f;
}