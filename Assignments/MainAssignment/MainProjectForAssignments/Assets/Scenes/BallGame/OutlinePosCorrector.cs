using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinePosCorrector : MonoBehaviour
{
    public GameObject player;
    void LateUpdate()
    {
        transform.position = player.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<PlayerController>().grounded = true;
        Debug.Log("Enter", other);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        player.GetComponent<PlayerController>().grounded = false;
        Debug.Log("Exit", other);

    }
}
