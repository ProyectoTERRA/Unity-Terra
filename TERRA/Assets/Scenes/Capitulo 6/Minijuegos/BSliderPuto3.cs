using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BSliderPuto3 : MonoBehaviour
{ // Start is called before the first frame update
    public static bool Barempty, active, start, Trigger;
    public static int valF = 100;

    public MiniPuto2 mini;
    public static float speed;

    public Slider Bar;
    private DivIzqM DV;

    [SerializeField] private GameObject view;
    void Start()
    {
        DV = GetComponent<DivIzqM>();
        Barempty = false;
        Bar.value = valF;

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
            active = false;
            Trigger = true;

        }

        if (Trigger)
        {
           
            DV.MINUS();
            Trigger = false;
        }

    }

    public void Refill()
    {
        Debug.Log("STAAAAAAAAAAAAAART");
        Bar.value = valF;
        StartCoroutine(WAIT());
        
    }

    public IEnumerator WAIT()
    {
        yield return new WaitForSeconds(.1f);

        start = true;
        Barempty = false;

    }

    public IEnumerator push()
    {

        yield return new WaitForSeconds(speed);

        Debug.Log("DIM");
        if (Bar.value > 0 && !Barempty)
        {
            Bar.value = Bar.value - 2;
        }


        if (!Barempty && active)
        {
            StartCoroutine(push());
        }


    }
}
