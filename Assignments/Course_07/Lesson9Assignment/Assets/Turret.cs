using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.up = (Vector3)mousePos-transform.position;
    }
}