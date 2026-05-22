using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed   = 10f;
    private Vector3 velocity;
    private float xInput;
    private float zInput;
    public float xRotationSpeed = 100f;
    private Vector3 moveDirection;
    private float turnInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        float xRotation = xInput * xRotationSpeed * Time.deltaTime;
        Vector3 rotation = new Vector3(0f, turnInput * xRotationSpeed * Time.deltaTime, 0f);
        transform.Rotate(rotation);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      

      
    }
    void FixedUpdate()
    {
        moveDirection = transform.forward * zInput + transform.right * xInput;
       
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turnInput * xRotationSpeed * Time.fixedDeltaTime, 0f));
    }



}
