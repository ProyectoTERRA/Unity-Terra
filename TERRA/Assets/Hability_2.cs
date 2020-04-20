﻿using UnityEngine;
using UnityEngine.UI;

public class Hability_2 : MonoBehaviour
{
    [SerializeField] private GameObject inv;
    public Sprite DoubleJump;
    public Sprite LongJump;
    public Sprite Invisible;
    public Sprite Dash;

    public bool disp;
    public bool act;

    public float actD;
    public float dispD;

    public Color ac = new Color(0.8679245f, 0.3561766f, 0.3814742f, 1f);


    public SpriteRenderer spr;

    public static string set = "Dash";

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        if (set == "Double_Jump")
        {
            spr.sprite = DoubleJump;
            dispD = 120;
            actD = 10;
        }

        else if (set == "Long_Jump")
        {
            spr.sprite = LongJump;
            dispD = 120;
            actD = 5;
        }
        else if (set == "Invisible")
        {
            spr.sprite = Invisible;
            dispD = 240;
            actD = 5;
        }

        else if (set == "Dash")
        {
            spr.sprite = Dash;
            dispD = 20;
            actD = 1;
        }

        inv.GetComponent<Image>().sprite = spr.sprite;

        disp = true;
        act = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (disp)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                act = true;
                disp = false;
                Invoke("Activate", actD);
            }
            spr.color = Color.white;
        }
        else if (act)
        {


            spr.color = ac;
            Debug.Log(spr.color);
        }
        else if (!act && !disp)
        {
            spr.color = Color.gray;
        }


    }


    public void Activate()
    {
        act = false;
        disp = false;
        Invoke("Dispo", dispD);

    }

    public void Dispo()
    {
        act = false;
        disp = true;

    }
}
