using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFixShoeToFinger : MonoBehaviour
{
    public int touchID;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetTouch(touchID).phase != TouchPhase.Ended)
        //transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchID).position) + new Vector3(0,0,10);
        //else
        //{
        //    transform.position = new Vector3(100, 100, 0);
        //}
    }
}
