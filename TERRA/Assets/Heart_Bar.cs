using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Bar : MonoBehaviour
{
    public Sprite LIFE_5x10;
    public Sprite LIFE_5x9;
    public Sprite LIFE_5x8;
    public Sprite LIFE_5x7;
    public Sprite LIFE_5x6;
    public Sprite LIFE_5x5;
    public Sprite LIFE_5x4;
    public Sprite LIFE_5x3;
    public Sprite LIFE_5x2;
    public Sprite LIFE_5x1;
    public Sprite LIFE_5x0;

    public Sprite LIFE_4x8;
    public Sprite LIFE_4x7;
    public Sprite LIFE_4x6;
    public Sprite LIFE_4x5;
    public Sprite LIFE_4x4;
    public Sprite LIFE_4x3;
    public Sprite LIFE_4x2;
    public Sprite LIFE_4x1;
    public Sprite LIFE_4x0;


    public Sprite LIFE_3x6;
    public Sprite LIFE_3x5;
    public Sprite LIFE_3x4;
    public Sprite LIFE_3x3;
    public Sprite LIFE_3x2;
    public Sprite LIFE_3x1;
    public Sprite LIFE_3x0;

    public int type;
    public int life;
    public int hearts;

    void Start()
    {
        if (type == 1)
        {
            Debug.Log("Tipo: " + type);
            type = 1;
            hearts = 6;
            Debug.Log("Corazones: " + hearts);
        }
        if (type == 2)
        {
            Debug.Log("Tipo: " + type);
            type = 2;
            hearts = 8;
            Debug.Log("Corazones: " + hearts);
        }
        if (type == 3)
        {
            Debug.Log("Tipo: " + type);
            type = 3;
            hearts = 10;
            Debug.Log("Corazones: " + hearts);
        }

    }

    // Update is called once per frame
    void Update()
    {        
        
        switch (type)
        {
            case 1:
                {   
                    if (Input.GetKeyDown(KeyCode.P))
                    {                        
                        if (hearts > 0) {
                            hearts--;
                        }
                        Debug.Log("Corazones: " + hearts);
                    }

                    if(hearts == 6)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x6;
                    }

                    else if(hearts == 5)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x5;
                    }

                    else if (hearts == 4)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x4;
                    }

                    else if (hearts == 3)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x3;
                    }

                    else if (hearts == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x2;
                    }

                    else if (hearts == 1)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x1;
                    }

                    else if (hearts == 0)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x0;
                    }

                    break;
                }

            case 2:
                {
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        if (hearts > 0)
                        {
                            hearts--;
                        }
                        Debug.Log("Corazones: " + hearts);

                    }

                    if (hearts == 8)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x8;
                    }

                    else if (hearts == 7)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x7;
                    }

                    else if (hearts == 6)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x6;
                    }

                    else if (hearts == 5)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x5;
                    }

                    else if (hearts == 4)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x4;
                    }

                    else if (hearts == 3)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x3;
                    }

                    else if (hearts == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x2;
                    }

                    else if (hearts == 1)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x1;
                    }

                    else if (hearts == 0)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x0;
                    }


                    break;
                }

            case 3:
                {
                    if (Input.GetKeyDown(KeyCode.P)) {                         
                        if (hearts > 0)
                        {
                            hearts--;
                        }
                        Debug.Log("Corazones: " + hearts);
                    }
                    if (hearts == 10)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x10;
                    }
                    else if (hearts == 9)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x9;
                    }
                    else if (hearts == 8)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x8;
                    }
                    else if (hearts == 7)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x7;
                    }
                    else if (hearts == 6)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x6;
                    }

                    else if (hearts == 5)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x5;
                    }
                    else if (hearts == 4)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x4;
                    }

                    else if (hearts == 3)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x3;
                    }
                    else if (hearts == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x2;
                    }
                    else if (hearts == 1)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x1;
                    }
                    else if (hearts == 0)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x0;
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }     

        if(hearts == 6)
        {

        }
        else if(hearts == 5)
        {

        }
        else if(hearts == 4)
        {

        }
        else if(hearts == 3)
        {

        }
        else if(hearts == 2)
        {

        }
        else if(hearts == 1)
        {

        }
        else if (hearts == 1)
        {

        }
    }
}
