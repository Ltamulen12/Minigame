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
    private float turnSpeed = 150.0f;
    public float verticalInput;
    public Transform leftProjectileSpawnPoint; // Left bullet spawn point
    public Transform rightProjectileSpawnPoint; // Right bullet spawn point
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

        if (Input.GetKeyDown(KeyCode.J))
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
