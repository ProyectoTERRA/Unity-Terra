using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hability_1 : MonoBehaviour
{

    public Sprite DoubleJump;
    public Sprite LongJump;
    public Sprite Invisible;
    public Sprite Dash;

    public Color g;

    public SpriteRenderer spr;

    public string set = "Double_Jump";

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = Color.white;
        g = new Color(108.000f, 152.000f, 241.000f, 1.000f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spr.color);
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(spr.color);
            spr.color = g;
        }
    }
}
