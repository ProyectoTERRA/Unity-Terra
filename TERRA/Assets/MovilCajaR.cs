using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovilCajaR : MonoBehaviour
{
    private SpriteRenderer Beam;
    private BoxCollider2D Burn;
    private float Ini, Fin, Rot;
    // Start is called before the first frame update
    void Start()
    {
        Ini = -37.5f;
        Fin = 38.5f;
        Beam = GetComponent<SpriteRenderer>();
        StartCoroutine(Return());

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Scan()
    {
        float cont = 0;
        Rot = Ini;
        transform.rotation = Quaternion.Euler(0f, 0f, Ini);
        Beam.enabled = true;

        while (Rot < Fin)
        {
            yield return new WaitForSeconds(0.026f);
            cont = cont + 0.0394736842f;
            Rot = Rot + 1;
            transform.rotation = Quaternion.Euler(0f, 0f, Rot);
        }
        Debug.Log(cont);
        StartCoroutine(Return());

    }

    IEnumerator Return()
    {
        float cont = 0;
        Rot = Ini;
        transform.rotation = Quaternion.Euler(0f, 0f, -Ini);
        Beam.enabled = true;

        while (Rot < Fin)
        {
            yield return new WaitForSeconds(0.026f);
            cont = cont - 0.0394736842f;
            Rot = Rot + 1;
            transform.rotation = Quaternion.Euler(0f, 0f, -Rot);
        }
        Debug.Log(cont);
        StartCoroutine(Scan());

    }
}
