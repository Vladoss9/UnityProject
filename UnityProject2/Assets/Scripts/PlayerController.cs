using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jupmForce = 7f;
    public float groundDistance = 0.1f;
    public LayerMask groundLayer;

    public CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        CheckIfGrounded();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            Debug.Log("Прыжок");
            velocity.y = Mathf.Sqrt(jupmForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void CheckIfGrounded()
    {
        RaycastHit hit;
        float extraHeight = 0.01f;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit,
        characterController.height / 2 + groundDistance + extraHeight, groundLayer);
    }
}
