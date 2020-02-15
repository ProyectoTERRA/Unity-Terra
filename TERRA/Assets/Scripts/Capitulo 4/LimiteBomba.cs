using System.Collections;
using UnityEngine;

public class LimiteBomba : MonoBehaviour
{
    public GameObject c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20;
    public GameObject bombas, latas, mensaje1, mensaje2, mensaje3, counter;
    int contador = 0;

    private void Update()
    {
        if (contador == 0) { StartCoroutine(men1()); }
        if (contador == 1) { StartCoroutine(men2()); }
        if (contador == 2) { StartCoroutine(men3()); }
        if (contador == 3) { StartCoroutine(men4()); }
        if (contador == 4) { StartCoroutine(men5()); }
    }
    IEnumerator men1()
    {
        yield return new WaitForSeconds(1);
        mensaje1.SetActive(true);
        contador = 1;
    }
    IEnumerator men2()
    {
        yield return new WaitForSeconds(1);
        mensaje1.SetActive(false);
        mensaje2.SetActive(true);
        contador = 2;
    }
    IEnumerator men3()
    {
        yield return new WaitForSeconds(1);
        mensaje2.SetActive(false);
        mensaje3.SetActive(true);
        contador = 3;
    }
    IEnumerator men4()
    {
        yield return new WaitForSeconds(1);
        mensaje3.SetActive(false);
        counter.SetActive(true);
        latas.SetActive(true);
        contador = 4;
    }
    IEnumerator men5()
    {
        yield return new WaitForSeconds(1);
        bombas.SetActive(true);
        contador = 5;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "bomba1")
        {
            c1.transform.position = new Vector2(-8.5f, 2.5f);
            c1.SetActive(false);
        }
        if (collision.name == "bomba2")
        {
            c2.transform.position = new Vector2(-8.5f, 2.5f);
            c2.SetActive(false);
        }
        if (collision.name == "bomba3")
        {
            c3.transform.position = new Vector2(-6.5f, 2.5f);
            c3.SetActive(false);
        }
        if (collision.name == "bomba4")
        {
            c4.transform.position = new Vector2(-6.5f, 2.5f);
            c4.SetActive(false);
        }
        if (collision.name == "bomba5")
        {
            c5.transform.position = new Vector2(-4.5f, 2.5f);
            c5.SetActive(false);
        }
        if (collision.name == "bomba6")
        {
            c6.transform.position = new Vector2(-4.5f, 2.5f);
            c6.SetActive(false);
        }
        if (collision.name == "bomba7")
        {
            c7.transform.position = new Vector2(-2.5f, 2.5f);
            c7.SetActive(false);
        }
        if (collision.name == "bomba8")
        {
            c8.transform.position = new Vector2(-0.5f, 2.5f);
            c8.SetActive(false);
        }
        if (collision.name == "bomba9")
        {
            c9.transform.position = new Vector2(2.5f, 2.5f);
            c9.SetActive(false);
        }
        if (collision.name == "bomba10")
        {
            c10.transform.position = new Vector2(4.5f, 2.5f);
            c10.SetActive(false);
        }
        if (collision.name == "bomba11")
        {
            c11.transform.position = new Vector2(6.5f, 2.5f);
            c11.SetActive(false);
        }
        if (collision.name == "bomba12")
        {
            c12.transform.position = new Vector2(8.5f, 2.5f);
            c12.SetActive(false);
        }
        if (collision.name == "bomba13")
        {
            c13.transform.position = new Vector2(10.5f, 2.5f);
            c13.SetActive(false);
        }
        if (collision.name == "bomba14")
        {
            c14.transform.position = new Vector2(12.5f, 2.5f);
            c14.SetActive(false);
        }
        if (collision.name == "bomba15")
        {
            c15.transform.position = new Vector2(14.5f, 2.5f);
            c15.SetActive(false);
        }
        if (collision.name == "bomba16")
        {
            c16.transform.position = new Vector2(16.5f, 2.5f);
            c16.SetActive(false);
        }
        if (collision.name == "bomba17")
        {
            c17.transform.position = new Vector2(18.5f, 2.5f);
            c17.SetActive(false);
        }
        if (collision.name == "bomba18")
        {
            c18.transform.position = new Vector2(20.5f, 2.5f);
            c18.SetActive(false);
        }
        if (collision.name == "bomba19")
        {
            c19.transform.position = new Vector2(22.5f, 2.5f);
            c19.SetActive(false);
        }
        if (collision.name == "bomba20")
        {
            c20.transform.position = new Vector2(24.5f, 2.5f);
            c20.SetActive(false);
        }
    }
}
