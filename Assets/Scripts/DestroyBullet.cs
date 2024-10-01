using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object the bullet collided with is tagged as "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}