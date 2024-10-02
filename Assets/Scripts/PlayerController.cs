using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private float horizontalInput;
    public GameObject Bullet;
    public float speed = 15.0f;
    private float turnSpeed = 150.0f;
    public Transform leftProjectileSpawnPoint; // Left bullet spawn point
    public Transform rightProjectileSpawnPoint; // Right bullet spawn point
    private float forwardInput;
    public float BulletSpeed = 20.0f;
    public float mouseSensitivity = 1000.0f; // Sensitivity for mouse rotation


    // Update is called once per frame
    void Update()
    {
       horizontalInput = Input.GetAxis("Horizontal");
       forwardInput = Input.GetAxis("Vertical");

        //moves the player forward and back
       transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

       // allows player to strafe
       transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //uses mouse to aim
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up, mouseX);

        if (Input.GetKeyDown(KeyCode.Mouse0)) //shoots with left click
        {
            // Launch a projectile from the left spawn point
            GameObject leftProjectile = Instantiate(Bullet, leftProjectileSpawnPoint.position, leftProjectileSpawnPoint.rotation);
            Rigidbody leftProjectileRb = leftProjectile.GetComponent<Rigidbody>();
            leftProjectileRb.velocity = leftProjectileSpawnPoint.forward * BulletSpeed;

            // Launch a projectile from the right spawn point
            GameObject rightProjectile = Instantiate(Bullet, rightProjectileSpawnPoint.position, rightProjectileSpawnPoint.rotation);
            Rigidbody rightProjectileRb = rightProjectile.GetComponent<Rigidbody>();
            rightProjectileRb.velocity = rightProjectileSpawnPoint.forward * BulletSpeed;
        }
    }
}
