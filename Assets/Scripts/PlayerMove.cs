using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotatinoSpeed;
    [SerializeField] private GameObject bulletPrefab;

    private BaseGun _baseGun;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        _baseGun = new Pistol(10, 2,0.5f , bulletPrefab);
    }

    void Update()
    {
        Move();
        MouseRotate();
        if (Input.GetKeyDown(KeyCode.Mouse0) && _baseGun.currentMagazineSize > 0)
        {
            
            _baseGun.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _baseGun.Reload();
        }
        _baseGun.Update();
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
                controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, targetRotation, Time.deltaTime * rotatinoSpeed);
            }
        }
    }
}
