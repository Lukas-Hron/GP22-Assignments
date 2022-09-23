using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBasedOnGroundNormal : MonoBehaviour
{
    public RaycastHit hit;
    public Vector3 currentUpDir;
    public float rotationMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit);
        if (hit.distance < 1)
        {
            currentUpDir = Vector3.MoveTowards(currentUpDir, hit.normal, Time.deltaTime * rotationMultiplier);
            transform.up = currentUpDir;
        }
        else
        {

        }
    }
}
