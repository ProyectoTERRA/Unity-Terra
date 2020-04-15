using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text Clock;
    private float T;
    private int time;
    public static bool Act, ZERO;
    // Start is called before the first frame update
    void Start()
    {
        Act = true;
        ZERO = false;
        T = 150;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Act)
        {
            T -= Time.deltaTime;
            time = (int)T + 1;

            if (time < 10.1f)
            {
                Clock.text = T.ToString("00");
            }
            else
            {
                Clock.text = T.ToString("f0");
            }
            if(T < 0.0f)
            {
                Act = false;
                ZERO = true;
            }
        }

    }
}
