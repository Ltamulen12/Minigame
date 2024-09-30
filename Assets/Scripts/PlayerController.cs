using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float horizontalInput;
    public GameObject Bullet;
    public float speed = 15.0f;
    private float turnSpeed =150.0f;
    public float verticalInput;
    public Transform projectileSpawnPoint;
    private float forwardInput;
    public float BulletSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
       horizontalInput = Input.GetAxis("Horizontal");
       forwardInput = Input.GetAxis("Vertical");
        //moves the player forward
       transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
       // rotates the player 
       transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            GameObject projectile = Instantiate(Bullet, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.velocity = projectileSpawnPoint.forward * BulletSpeed;
        }

    }
}