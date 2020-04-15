using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosEsferas : MonoBehaviour
{
    private int CNormales;
    private int CTranquilizantes;
    private int CDesactivadoras;
    private int CParalizantes;

    private bool effecting;
    // Start is called before the first frame update
    void Start()
    {
        effecting = false;
        CNormales = 0;
        CTranquilizantes = 0;
        CDesactivadoras = 0;
        CParalizantes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("N: " + CNormales);
        Debug.Log("T: " + CTranquilizantes);
        Debug.Log("D: " + CDesactivadoras);
        Debug.Log("P: " + CParalizantes);

        if (gameObject.tag == "Crawler")
        {
            if(CParalizantes >= 1 && !effecting)
            {
                StartCoroutine(ParalizEffect());
            }
            if (CDesactivadoras >= 1 && !effecting)
            {
                StartCoroutine(DesacEffect());
            }
            if (CNormales >= 2 && !effecting)
            {
                StartCoroutine(NormalEffect());
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Normal")
        {
            CNormales++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Tranqui")
        {
            CTranquilizantes++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Desac")
        {
            CDesactivadoras++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Paraliz")
        {
            CParalizantes++;
            Destroy(collision.gameObject);
        }
    }
    public IEnumerator NormalEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        effecting = true;
        
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        if (gameObject.tag == "Crawler")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Crawler>().enabled = false;
        }
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().color = Color.grey;

    }
    public IEnumerator TranquiEffect()
    {
        yield return new WaitForSeconds(1f);

    }
    public IEnumerator DesacEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        effecting = true;
        GetComponent<SpriteRenderer>().color = Color.blue;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        if (gameObject.tag == "Crawler")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Crawler>().enabled = false;
        }
        yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().color = Color.grey;
        

    }
    public IEnumerator ParalizEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        effecting = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        if(gameObject.tag == "Crawler")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Crawler>().enabled = false;
        }
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().color = deafault;
        if (gameObject.tag == "Crawler")
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true; 
            GetComponent<Crawler>().enabled = true;
        }
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        effecting = false;
        CParalizantes = 0;
    }
}
