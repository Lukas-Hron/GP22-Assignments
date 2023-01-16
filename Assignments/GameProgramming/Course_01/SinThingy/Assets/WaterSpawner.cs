using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{

    public GameObject waterDropletPre;
    GameObject bufferObj;
    List<GameObject> waterDroplets;
    [SerializeField] Gradient waterGradient;
    [SerializeField] int numberOfWaterDropletsPerRow;
    [SerializeField] int numberOfRows;
    int rowCount;
    float currentXPos;
    Color colorToAssign;

    // Start is called before the first frame update
    void Start()
    {
        waterDroplets = new List<GameObject>();
        for (int e = 0; e < numberOfRows; e++)
        {
            rowCount++;

            for (float i = 0; i < numberOfWaterDropletsPerRow+1; i++)
            {
                bufferObj = Instantiate(waterDropletPre);
           

                colorToAssign = waterGradient.Evaluate(Mathf.InverseLerp(0, numberOfRows, rowCount));
                currentXPos = ((i / numberOfWaterDropletsPerRow) * 12f) - 6f;

                bufferObj.GetComponent<WaterDroplet>().InitializeWaterDroplet(numberOfRows, rowCount, currentXPos, colorToAssign);
                bufferObj.transform.position = bufferObj.GetComponent<WaterDroplet>().OriginPos;
                waterDroplets.Add(bufferObj);
            }

        }

        GetComponent<WaterAnimator>().PlayAnimation(waterDroplets);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
