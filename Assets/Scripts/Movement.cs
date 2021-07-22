using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3.0f;

    private float mouseX;

    public float mouseSensitivity = 100.0f;

    private float yRotation = 0f;

    private Vector3 offset = new Vector3(0f, 4.5f, 0f);

    public Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        rb.constraints = RigidbodyConstraints.None;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if(!Input.anyKey)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.angularVelocity = Vector3.zero;
        }
        
        
        Ray ray = new Ray(transform.position, Vector3.down);//stores a ray from origin in direction
        RaycastHit hit;//stores info about what ray hits

        Quaternion rot = Quaternion.identity;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag != "border")
            {
                transform.position = hit.point + offset;
                Vector3 slope = Vector3.ProjectOnPlane(transform.forward, hit.normal);
                rot = Quaternion.LookRotation(slope, hit.normal);

                /*
                float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
                */
            }
        }
        
        

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(rot.eulerAngles.x, yRotation, rot.eulerAngles.z);
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "zombie")
        {
            Debug.Log("Game Over");
        }
        
    }
}
