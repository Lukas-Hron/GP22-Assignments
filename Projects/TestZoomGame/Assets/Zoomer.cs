using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour
{
    public GameObject zoomOrigin;
    [Range(0.0f, 1.0f)]
    public float zoomLevel;

    private void Start()
    {
        Camera cam;
        cam = gameObject.GetComponent<Camera>();
    }
    void Update()
    {

        //Log zoom
        float zoom = Mathf.Lerp(Mathf.Log(1), Mathf.Log(500), zoomLevel);
        zoom = Mathf.Exp(zoom);
        zoomOrigin.transform.localScale = new Vector3(zoom, zoom, zoom);

        ////Normal zoom (doesn't work)
        //float zoom = Mathf.Lerp(1, 500, zoomLevel
        //);
        //zoomOrigin.transform.localScale = new Vector3(zoom, zoom, zoom);
    }

    void MoveToScale()
    {

    }
}
