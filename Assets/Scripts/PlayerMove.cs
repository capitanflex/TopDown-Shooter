using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
   
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
      
    }

    void Update()
    {
        Move();
        MouseRotate();
        
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       
        if (movement.magnitude > 1.0f)
            movement.Normalize();
        
        movement *= speed * Time.deltaTime;
        controller.Move(movement);
    }

    public void MouseRotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        float distance;
        
        if (plane.Raycast(ray, out distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);
            
            Vector3 direction = targetPoint - transform.position;
            direction.y = 0;
            direction.Normalize();
            
            if (direction.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
