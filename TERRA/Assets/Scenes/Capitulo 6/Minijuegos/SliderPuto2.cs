using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPuto2 : MonoBehaviour
{
    public static bool Target, active;
    private bool dir;
    public Slider Bar;
    public int cont;
    private float time;
    public static float speed;

    void Start()
    {
        time = 0;
        dir = true;
        Target = false;
        active = true;
        Bar.value = 0;
        //StartCoroutine(push());
    }

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
            if (Bar.value >= 48 && Bar.value <= 152)
            {
                Target = true;
            }
            else
            {
                Target = false;
            }

            push();
        }
        if (Bar.value == 0 && active)
        {
            dir = true;
        }
        else if (Bar.value == 200 && active)
        {
            Debug.Log(cont);
            dir = false;
        }

    }

    public void reset()
    {
        active = true;
        Bar.value = 0;
        //StartCoroutine(push());
    }
    public IEnumerator win()
    {
        yield return new WaitForSeconds(1.5f);
        Target = true;
        Bar.enabled = false;

    }
    public void push()
    {
        time += Time.deltaTime;
        if (time >= 0.017f)
        {
            if (dir)
            {
                Bar.value = Bar.value + 1;
            }
            else
            {
                Bar.value = Bar.value - 1;
            }
            time = 0;
        }
    }
    public IEnumerator push2()
    {
        if (dir)
        {
            Bar.value = Bar.value + 1;
        }
        else
        {
            Bar.value = Bar.value - 1;
        }
        yield return new WaitForSeconds(0.04f);



        if (active)
        {
            //StartCoroutine(push());
        }


    }
}
