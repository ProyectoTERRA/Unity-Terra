using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoMejorado : MonoBehaviour
{
    public float MultiplicadorCaida = 2.5f;
    public float Saltopequeno = 2f;
    Rigidbody2D myrb;

    void Awake()
    {
        Heart_Bar.Phearts = 3;
        myrb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(myrb.velocity.y < 0)
        {
            myrb.velocity += Vector2.up * Physics2D.gravity.y * (MultiplicadorCaida - 1) * Time.deltaTime * ChangeGravity.VG;
        }else if(myrb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            myrb.velocity += Vector2.up * Physics2D.gravity.y * (Saltopequeno - 1) * Time.deltaTime * ChangeGravity.VG;
        }
    }
}
