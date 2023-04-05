using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject spine;
    
    private Vector3 moveDirection;
    private float verticalVelocity = 0f; 
    private float mouseX = 0f; 
    private float mouseY = 0f;
    private CharacterController controller;
    private Camera cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        MouseRotate();
        Jump();
        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        animator.SetFloat("speedVertical", vertical);
        animator.SetFloat("speedHorizontal", horizontal);
        
        Vector3 moveHorizontal = transform.right * horizontal;
        Vector3 moveVertical = transform.forward * vertical;
        moveDirection = moveHorizontal + moveVertical;
        moveDirection.Normalize();
        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);
    }

    public void MouseRotate()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        transform.rotation = Quaternion.Euler(0f, mouseX, 0f);
        // cam.transform.localRotation = Quaternion.Euler(mouseY, 0f, 0.01f);
        
        // float xAngle = Camera.main.transform.eulerAngles.x;
        // if (xAngle > 180) xAngle -= 360;
        // xAngle = Mathf.Clamp(xAngle, -90f, 90f);
        // print(xAngle);
        spine.transform.localEulerAngles = new(mouseY, 0f, 0f);
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        
        moveDirection.y = verticalVelocity;
    }
}
