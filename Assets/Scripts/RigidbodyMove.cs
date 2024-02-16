using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//lines 7-13, 20-28 made using ChatGPT. reused from  attendance assignment 
public class rbmove : MonoBehaviour
{
    public float speed = 5f;  // Adjust the speed as needed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
// used fixed update since dealing with physics objects
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}


