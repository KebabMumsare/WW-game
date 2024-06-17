using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerGroundCheck;
    public Transform hastGroundCheck;
    public Transform groundCheck;
    public Player player;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float speed;
    public float gravity = -9.82f;

    public Vector3 velocity;
    public bool isGrounded;
    bool inInventory;
    bool interacting;

    void Start()
    {
        groundCheck = playerGroundCheck;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inInventory)
            {
                inInventory = false;
            }
            else
            {
                inInventory = true;
            }
        }

        if (!inInventory && !interacting)
        {
            HandleMovement();
            HandleFall();
        }
        if (player.isMounted)
        {
            groundCheck = hastGroundCheck;
        }
        else
        {
            groundCheck = playerGroundCheck;
        }
        /*else
        {
            Vector3 move = Vector3.zero;
            velocity = Vector3.zero;
        }*/

        // Fixa med Onhourse parent

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "interact")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("INSIDE INTERACT AREA");
                interacting = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                interacting = false;
            }
        }
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6f;
        }
        else
        {
            speed = 3f;
        }

        controller.Move(move * speed * Time.deltaTime);
    }
    void HandleFall()
    {
        Debug.Log("Handling fall");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
