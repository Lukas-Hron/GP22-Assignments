using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.AddComponent<Rigidbody2D>();
            newBullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
        }

    }
}
