using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardsc3 : MonoBehaviour
{
    string nombre1;

    private int CNormales;
    private int CTranquilizantes;
    private int CDesactivadoras;
    private int CParalizantes;

    public static bool effecting;
    private bool efecT;
    // Start is called before the first frame update
    void Start()
    {
        efecT = false;
        effecting = false;
        CNormales = 0;
        CTranquilizantes = 0;
        CParalizantes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("N: " + CNormales);
        Debug.Log("T: " + CTranquilizantes);
        Debug.Log("D: " + CDesactivadoras);
        Debug.Log("P: " + CParalizantes);

        if (gameObject.tag == "enemigo1")
        {
            if (CParalizantes >= 1 && !efecT)
            {
                StartCoroutine(ParalizEffect());
            }
            if (CTranquilizantes >= 1 && !efecT)
            {
                StartCoroutine(TranquiEffect());
            }
            if (CNormales >= 2 && !efecT)
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
        if (collision.gameObject.tag == "Paraliz")
        {
            CParalizantes++;
            Destroy(collision.gameObject);
        }
    }
    public IEnumerator NormalEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        efecT = true;
        effecting = true;
        if (gameObject.tag == "enemigo1")
        {
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            eliminarEnemyesC3.guardias++;
            nombre1 = gameObject.name;
            codificadorNormal();
        }
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator TranquiEffect()
    {
        efecT = true;
        effecting = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        if (gameObject.tag == "enemigo1")
        {
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            eliminarEnemyesC3.guardias++;
            nombre1 = gameObject.name;
            codificadorTranquilizante();
        }
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator ParalizEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        effecting = true;
        efecT = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;

        if (gameObject.tag == "enemigo1")
        {
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().color = deafault;
        if (gameObject.tag == "enemigo1")
        {
            GetComponent<EnemyMove>().enabled = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
        }
        efecT = false;
        effecting = false;
        CParalizantes = 0;
    }
    private void codificadorNormal()
    {
        if(nombre1 == "e1")
        {
            GameController.e1 = true;
        }
        if (nombre1 == "e2")
        {
            GameController.e2 = true;
        }
        if (nombre1 == "e3")
        {
            GameController.e3 = true;
        }
        if (nombre1 == "e4")
        {
            GameController.e4 = true;
        }
        if (nombre1 == "e5")
        {
            GameController.e5 = true;
        }
        if (nombre1 == "e6")
        {
            GameController.e6 = true;
        }
        if (nombre1 == "e7")
        {
            GameController.e7 = true;
        }
    }
    private void codificadorTranquilizante()
    {
        if (nombre1 == "e1")
        {
            GameController.t1 = true;
        }
        if (nombre1 == "e2")
        {
            GameController.t2 = true;
        }
        if (nombre1 == "e3")
        {
            GameController.t3 = true;
        }
        if (nombre1 == "e4")
        {
            GameController.t4 = true;
        }
        if (nombre1 == "e5")
        {
            GameController.t5 = true;
        }
        if (nombre1 == "e6")
        {
            GameController.t6 = true;
        }
        if (nombre1 == "e7")
        {
            GameController.t7 = true;
        }
    }
}
