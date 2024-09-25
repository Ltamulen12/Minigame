using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float horizontalInput;
    private float forwardInput;
    private float speed = 10.0f;
    private float turnSpeed = 200.0f;
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

       //moves the player move forward
       transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
       // moves the player side to side
       transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);    
    }
}
