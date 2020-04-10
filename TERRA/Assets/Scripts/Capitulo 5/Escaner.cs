using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaner : MonoBehaviour
{
    private SpriteRenderer Beam;
    private BoxCollider2D Burn;
    private float Ini, Fin ,Rot;
    // Start is called before the first frame update
    void Start()
    {
        Ini = -37.5f;
        Fin = 38.5f;
        Beam = GetComponent<SpriteRenderer>();
        Burn = GetComponent<BoxCollider2D>();
        Beam.enabled = false;
        Burn.enabled = false;
        StartCoroutine(Active());

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {


            col.SendMessage("RATAKnockBack", transform.position.x);


        }
    }

    
    IEnumerator Active()
    {

        yield return new WaitForSeconds(5f);

        StartCoroutine(Scan());

    }
    IEnumerator Scan()
    {
        float cont = 0;
        Rot = Ini;
        transform.rotation = Quaternion.Euler(0f, 0f, Ini);
        Beam.enabled = true;
        Burn.enabled = true;

        while (Rot < Fin)
        {
            yield return new WaitForSeconds(0.026f);
            cont = cont + 0.0394736842f; 
            Rot = Rot + 1;
            transform.rotation = Quaternion.Euler(0f, 0f, Rot);
        }
        Beam.enabled = false;
        Burn.enabled = false;
        StartCoroutine(Active());
        Debug.Log(cont);

    }
}
