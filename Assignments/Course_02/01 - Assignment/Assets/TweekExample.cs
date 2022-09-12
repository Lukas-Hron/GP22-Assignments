using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweekExample : MonoBehaviour
{

    public GameObject laserPrefab;
     float xPos;
     float yPos;
    public float fireRate = 0.2f;
    float timer;


    // Update is called once per frame
    void Update()
    {
        //fire laser
        if (Input.GetMouseButtonDown(0) && timer > fireRate)
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;

        //Rotation
        Vector2 aim = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = Vector2.Lerp(transform.position, aim, Time.deltaTime * 5000);



        if (Input.GetKeyDown(KeyCode.W))
        {
            yPos++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            yPos--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            xPos++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            xPos--;
        }


        transform.parent.position = new Vector3(xPos, yPos);
        transform.position = new Vector3(xPos, yPos + (Mathf.Sin((float)Time.timeSinceLevelLoadAsDouble * 5) / 5));



    }
}
