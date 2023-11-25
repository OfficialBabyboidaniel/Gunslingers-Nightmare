using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 4f;
    private Rigidbody2D rb;

    public AudioSource audioSource;
    public AudioClip audioClip;
    [SerializeField] private Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Space) || (Gamepad.all.Count > 0 && Gamepad.all[0].dpad.up.IsPressed()))
        {
            if (!audioSource.isPlaying) audioSource.PlayOneShot(audioClip);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
}
