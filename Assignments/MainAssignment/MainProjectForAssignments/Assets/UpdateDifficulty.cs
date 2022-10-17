using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateDifficulty : MonoBehaviour
{
    public Slider diffSliderGet;
    private Animator animator;

    public int diffValue;
    // Start is called before the first frame update
    void Start()
    {
        diffSliderGet.onValueChanged.AddListener(delegate { OnValueChanged(); });
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnValueChanged()
    {
        
        animator.SetInteger("difficulty",(int)diffSliderGet.value);
        diffValue =(int)diffSliderGet.value;
        animator.SetBool("switchDifficulty", true);
    }
}
