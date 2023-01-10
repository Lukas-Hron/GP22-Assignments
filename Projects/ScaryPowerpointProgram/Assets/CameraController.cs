using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject puzzle1, puzzle2;
    public AnimationCurve curve;

    Camera cam;
    public float transitionTimeSec;
    public float lerpTime;
    public float zoomLevel, TargetZoomLevel;
    public Transform cameraPos, targetCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lerpTime != 1)
            lerpTime = Mathf.Clamp(lerpTime + (Time.deltaTime / transitionTimeSec), 0, 1);

        float zoom = LerpWithoutClamp(zoomLevel, TargetZoomLevel, curve.Evaluate(lerpTime));
        zoom = Mathf.Exp(zoom);
        cam.orthographicSize = zoom;
    }

    public void NextSlide(float time, float target, int custom)
    {
        lerpTime = 0;
        zoomLevel = TargetZoomLevel;
        TargetZoomLevel = target;
        transitionTimeSec = time;

        if (custom == 1)
        {
            puzzle1.SetActive(true);
        }
        if (custom == 2)
        {
            puzzle2.SetActive(true);
        }
;

    }
    float LerpWithoutClamp(float A, float B, float t)
    {
        return A + (B - A) * t;
    }
}
