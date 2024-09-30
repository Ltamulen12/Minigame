using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // Called when the bullet collides with another object
    void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Wall"))
    {
        Destroy(gameObject);
    }
}

}
