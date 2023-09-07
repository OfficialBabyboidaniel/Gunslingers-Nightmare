using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    private bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If the collision is with an object tagged as "Player,"
            Debug.Log("ccollion hit player");
            canMove = false;
        }
    }
}
