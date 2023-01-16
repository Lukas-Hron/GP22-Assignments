using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimator : MonoBehaviour
{
    public float speed = 1;
    public float size = 1;
    public float wavethingy = 1;
    public float waveYthingy = 1;
    bool startAnimation;
    float val;
    List<GameObject> waterDroplets;
    List<Vector3> waterDropletOrigins;
    public void PlayAnimation(List<GameObject> WaDro)
    {
        waterDroplets = WaDro;
        waterDropletOrigins = new List<Vector3>();

        foreach (GameObject droplett in waterDroplets)
        {
            waterDropletOrigins.Add(droplett.GetComponent<WaterDroplet>().OriginPos);
        }
        startAnimation = true;

    }
    private void Update()
    {

        if (startAnimation)
        {
            val += Time.deltaTime * speed;
            for (int i = 0; i < waterDroplets.Count; i++)
            {
                waterDroplets[i].transform.position = new Vector3(waterDroplets[i].transform.position.x, waterDropletOrigins[i].y + (Mathf.Sin(val+(waterDropletOrigins[i].x/wavethingy + waterDropletOrigins[i].y / waveYthingy)))*size, 0);
            }



        }
    }
}
