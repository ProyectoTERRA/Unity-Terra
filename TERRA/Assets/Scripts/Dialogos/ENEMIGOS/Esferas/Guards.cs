using System.Collections;
using UnityEngine;

public class Guards : MonoBehaviour
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
        if (gameObject.tag == "enemigo2")
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
        if (gameObject.tag == "enemigo2")
        {
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            nombre1 = gameObject.name;
            codificador();
        }
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator TranquiEffect()
    {
        efecT = true;
        effecting = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        if (gameObject.tag == "enemigo2")
        {
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            nombre1 = gameObject.name;
            codificador();
        }
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator ParalizEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        effecting = true;
        efecT = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;

        if (gameObject.tag == "enemigo2")
        {
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().color = deafault;
        if (gameObject.tag == "enemigo2")
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
    private void codificador()
    {
        Debug.Log("Nombre de enemigo " + nombre1);
        if (nombre1 == "e41" || nombre1 == "e42" || nombre1 == "e43" || nombre1 == "e44" || nombre1 == "e45" || nombre1 == "e46" || nombre1 == "e47" || nombre1 == "e48")
        {
            Debug.Log("Entroooooooooooooooooooooooooo");
            Botones.enemigos++;
        }
    }

}
