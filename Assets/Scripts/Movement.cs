using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3.0f;

    private float mouseX;

    public float mouseSensitivity = 100.0f;

    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
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

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(transform.rotation.x, yRotation, 0f);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "zombie")
        {
            Debug.Log("Game Over");
        }
    }
}
