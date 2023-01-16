using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDroplet : MonoBehaviour
{
    public Vector3 OriginPos;
    public void InitializeWaterDroplet(float layercount,float layer,float xPos,Color color)
    {
        SpriteRenderer spriteRn = GetComponent<SpriteRenderer>();
        spriteRn.color = color;
        spriteRn.sortingOrder = (int)(layercount-layer);
        OriginPos = new Vector3(xPos, ((layer / layercount) * 12f)/2 - 6f, 0f);
        transform.position = OriginPos;
        GetComponent<Animator>().speed = Random.Range(0.5f, 1.5f);
    }
}
