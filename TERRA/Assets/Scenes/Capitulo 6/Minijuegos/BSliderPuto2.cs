using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BSliderPuto2 : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Barempty, active, start;
    public static int valF = 400;

    public MiniPuto2 mini;

    public Slider Bar;
    [SerializeField] private GameObject  view;
    void Start()
    {
        mini = GetComponent<MiniPuto2>();
        Barempty = false;
        Bar.value = valF;
        StartCoroutine(push());

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Barra:" + active);
        if (start)
        {
            active = true;
            start = false;
            StartCoroutine(push());
        }
        if (!active)
        {
            Bar.enabled = false;
        }
        else
        {
            Bar.enabled = true;
        }

        if (Bar.value == 0 && active)
        {
            Barempty = true;
            if (!MiniPuto2.c1 && !MiniPuto2.c2 && !MiniPuto2.c3)
            {
                MiniPuto2.countE = 0;
            }
            else if (MiniPuto2.c1 && !MiniPuto2.c2 && !MiniPuto2.c3)
            {
                MiniPuto2.countE = 1;

            }
            else if (MiniPuto2.c1 && MiniPuto2.c2 && !MiniPuto2.c3)
            {
                MiniPuto2.countE = 3;
            }

            StartCoroutine(mini.FAIL());
            active = false;

        }

    }

    public void Refill()
    {
        Bar.value = valF;
    }

    public IEnumerator push()
    {

        yield return new WaitForSeconds(.05f);

        Debug.Log("DIM");
        if (Bar.value > 0 && !Barempty)
        {
            Bar.value = Bar.value - 1;
        }


        if (!Barempty && active)
        {
            StartCoroutine(push());
        }


    }
}
