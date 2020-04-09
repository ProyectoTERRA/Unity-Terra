using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPrueba : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool Barfull;

    public Slider Bar;

    void Start()
    {
        Barfull = false;
        Bar.value = 0;
        StartCoroutine(push());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && Bar.value <= 50 && !Barfull)
        {
            Bar.value = Bar.value + 5;
        }
        if(Bar.value == 50)
        {
            Barfull = true;
            
        }

    }
    public IEnumerator push()
    {

        yield return new WaitForSeconds(.05f);

        Debug.Log("DIM");
        if (Bar.value > 0 && !Barfull)
        {
            Bar.value = Bar.value - 1;
        }


        if (!Barfull)
        {
            StartCoroutine(push());
        }

        
    }
}
