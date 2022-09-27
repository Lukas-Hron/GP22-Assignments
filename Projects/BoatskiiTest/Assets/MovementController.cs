using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(transform.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(-transform.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(-transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(transform.right);
        }
    }
}
