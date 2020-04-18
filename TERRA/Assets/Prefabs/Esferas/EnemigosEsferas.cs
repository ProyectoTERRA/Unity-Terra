using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosEsferas : MonoBehaviour
{
    [SerializeField] private GameObject NOX;
    [SerializeField] private GameObject C1;
    [SerializeField] private GameObject C2;
    [SerializeField] private GameObject C3;

    [SerializeField] private GameObject B1;
    [SerializeField] private GameObject B2;
    [SerializeField] private GameObject B3;

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
            if(CParalizantes >= 1 && !efecT)
            {
                StartCoroutine(ParalizEffect());
            }
            if (CDesactivadoras >= 1 && !efecT)
            {
                StartCoroutine(DesacEffect());
            }
            if (CNormales >= 2 && !efecT)
            {
                StartCoroutine(NormalEffect());
            }
        }
        if (gameObject.tag == "Turret")
        {
            if (CParalizantes >= 2 && !efecT)
            {
                StartCoroutine(ParalizEffect());
            }
            if (CDesactivadoras >= 1 && !efecT)
            {
                StartCoroutine(DesacEffect());
            }
            if (CNormales >= 4 && !efecT)
            {
                StartCoroutine(NormalEffect());
            }
        }
        if (gameObject.name == "NOXINT")
        {
            if (CParalizantes >= 5 && !efecT)
            {
                StartCoroutine(ParalizNOXEffect());
            }
        }

        if (gameObject.tag == "GuardsCap5")
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

        if (gameObject.tag == "RAT")
        {

            if (CParalizantes >= 1 && !efecT)
            {
                Debug.Log("RAAAAAAAAAAAAT");
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
        efecT = true;
        effecting = true;
        
        

        if (gameObject.tag == "Crawler")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Crawler>().enabled = false;
        }
        if (gameObject.tag == "Turret")
        {
            Turret.act = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Turret>().enabled = false;
        }
        if(gameObject.tag == "RAT")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<RATA>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;

        }
        if (gameObject.tag == "GuardsCap5")
        {
            if (gameObject.name == "Guard1") { C1.SetActive(false); B1.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            if (gameObject.name == "Guard2") { C2.SetActive(false); B2.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            if (gameObject.name == "Guard3") { C3.SetActive(false); B3.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

        }
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().color = Color.grey;
        if (gameObject.tag != "Turret")
        {
            effecting = false;
        }
    }
    public IEnumerator TranquiEffect()
    {
        efecT = true;
        effecting = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        if (gameObject.tag == "GuardsCap5")
        {
            if (gameObject.name == "Guard1") { C1.SetActive(false); B1.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            if (gameObject.name == "Guard2") { C2.SetActive(false); B2.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            if (gameObject.name == "Guard3") { C3.SetActive(false); B3.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

        }
        if (gameObject.tag == "RAT")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<RATA>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;

        }
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().color = Color.grey;
        if (gameObject.tag != "Turret")
        {

            effecting = false;
        }
    }
    public IEnumerator DesacEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        efecT = true;
        effecting = true;
        GetComponent<SpriteRenderer>().color = Color.blue;


        if (gameObject.tag == "Crawler")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Crawler>().enabled = false;
        }
        if (gameObject.tag == "Turret")
        {
            Turret.act = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Turret>().enabled = false;
        }
       
        yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().color = Color.grey;
        if (gameObject.tag != "Turret")
        {
            effecting = false;
        }
            

    }
    public IEnumerator ParalizEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        effecting = true;
        efecT = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        

        if(gameObject.tag == "Crawler")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Crawler>().enabled = false;
        }
        if (gameObject.tag == "RAT")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<RATA>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;

        }
        if (gameObject.tag == "Turret")
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Turret>().enabled = false;
        }
        if (gameObject.tag == "GuardsCap5")
        {
            if (gameObject.name == "Guard1") { C1.SetActive(false); B1.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            if (gameObject.name == "Guard2") { C2.SetActive(false); B2.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            if (gameObject.name == "Guard3") { C3.SetActive(false); B3.SetActive(false); GetComponent<Prueba>().enabled = false; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; }
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            
        }
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().color = deafault;
        if (gameObject.tag == "Crawler")
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true; 
            GetComponent<Crawler>().enabled = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        if (gameObject.tag == "RAT")
        {
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<RATA>().enabled = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<BoxCollider2D>().enabled = true;

        }
        if (gameObject.tag == "Turret")
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<Turret>().enabled = true;
        }
        if (gameObject.tag == "GuardsCap5")
        {
            if (gameObject.name == "Guard1") { C1.SetActive(true); B1.SetActive(true); GetComponent<Prueba>().enabled = true; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; }
            if (gameObject.name == "Guard2") { C2.SetActive(true); B2.SetActive(true); GetComponent<Prueba>().enabled = true; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; }
            if (gameObject.name == "Guard3") { C3.SetActive(true); B3.SetActive(true); GetComponent<Prueba>().enabled = true; GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; }
            
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
            
        }
        efecT = false;
        effecting = false;
        CParalizantes = 0;
    }
    public IEnumerator ParalizNOXEffect()
    {
        efecT = true;
        Color deafault = NOX.GetComponent<SpriteRenderer>().color;
        effecting = true;
        NOX.GetComponent<SpriteRenderer>().color = Color.yellow;
        NOX.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(2f);
        NOX.GetComponent<SpriteRenderer>().color = deafault;
        NOX.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        efecT = false;
        effecting = false;
        CParalizantes = 0;
    }
}
