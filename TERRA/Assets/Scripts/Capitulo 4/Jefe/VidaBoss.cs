using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite vida20, vida19, vida18, vida17, vida16, vida15, vida14, vida13, vida12, vida11;
    public Sprite vida10, vida9, vida8, vida7, vida6, vida5, vida4, vida3, vida2, vida1, vida0;

    public int hearts;

    void Start()
    {
        hearts = 20;
        this.GetComponent<SpriteRenderer>().sprite = vida20;
    }

    // Update is called once per frame
    void Update()
    {
        if (hearts == 19)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida19;
        }
        if (hearts == 18)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida18;
        }
        if (hearts == 17)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida17;
        }
        if (hearts == 16)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida16;
        }
        if (hearts == 15)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida15;
        }
        if (hearts == 14)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida14;
        }
        if (hearts == 13)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida13;
        }
        if (hearts == 12)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida12;
        }
        if (hearts == 11)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida11;
        }
        if (hearts == 10)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida10;
        }
        if (hearts == 9)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida9;
        }
        if (hearts == 8)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida8;
        }
        if (hearts == 7)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida7;
        }
        if (hearts == 6)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida6;
        }
        if (hearts == 5)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida5;
        }
        if (hearts == 4)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida4;
        }
        if (hearts == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida3;
        }
        if (hearts == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida2;
        }
        if (hearts == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida1;
        }
        if(hearts == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = vida0;
        }
    }
    
}
