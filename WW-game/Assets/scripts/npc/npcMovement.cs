using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    int rng;
    public float targetTime = 5.0f;

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float speed = 6f;
    public float gravity = -9.82f;
    public Player player;

    Vector3 velocity;
    bool isGrounded;
    bool NPCinfront;
    bool NPClockOn;

    public Transform npcBody;
    public Transform playerBody;

    

    public bool canMoveForward = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            rng = Random.Range(0, 10);
            targetTime = 5f;
        }

        Debug.Log(canMoveForward);
        if (canMoveForward == false)
        {
            Rotate();
        }

        if (!player.isinteractingNPC)
        {
            if (rng >= 6)
            {
                HandleMovement();
            }

        }

        if (player.isinteractingNPC)
        {
            speed = 0f;
            RotateToPlayer();
        }
        else
        {
            speed = 3f;
        }
    }
    void HandleMovement()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.forward;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            speed = 6f;
            velocity.y += 100 * Time.deltaTime;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        controller.Move(move * speed * Time.deltaTime);
    }
    void Rotate()
    {
        float x = 90;
        npcBody.Rotate(Vector3.up * x);
    }

    void RotateToPlayer()
    {
        transform.LookAt(playerBody);
    }

}