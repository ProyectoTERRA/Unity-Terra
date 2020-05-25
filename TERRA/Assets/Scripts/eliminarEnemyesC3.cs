using UnityEngine;
using System.Collections;

public class eliminarEnemyesC3 : MonoBehaviour
{
    public static int guardias;
    public GameObject puerta, formula, formula2, key12;
    private int x;

    private bool inicia;
    GameObject enemigo;
    public static bool effecting;
    private bool efecT;
    public void Start()
    {
        efecT = false;
        effecting = false;
        guardias = 0;
        x = 0;
        inicia = true;
    }
    void Update()
    {
        if (guardias == 7)
        {
            Debug.Log(guardias);
            puerta.SetActive(true);
            key12.SetActive(false);
            if (x == 0)
            {
                formula.SetActive(true);
                formula2.SetActive(true);
                x = 1;
            }
        }
        if (inicia)
        {
            if (GameController.e1)
            {
                enemigo = GameObject.Find("e1");
                StartCoroutine(NormalEffect(enemigo));
            }
            if (GameController.e2)
            {
                enemigo = GameObject.Find("e2");
                StartCoroutine(NormalEffect(enemigo));
            }
            if (GameController.e3)
            {
                enemigo = GameObject.Find("e3");
                StartCoroutine(NormalEffect(enemigo));
            }
            if (GameController.e4)
            {
                enemigo = GameObject.Find("e4");
                StartCoroutine(NormalEffect(enemigo));
            }
            if (GameController.e5)
            {
                enemigo = GameObject.Find("e5");
                StartCoroutine(NormalEffect(enemigo));
            }
            if (GameController.e6)
            {
                enemigo = GameObject.Find("e6");
                StartCoroutine(NormalEffect(enemigo));
            }
            if (GameController.e7)
            {
                enemigo = GameObject.Find("e7");
                StartCoroutine(NormalEffect(enemigo));
            }
            if (GameController.t1)
            {
                enemigo = GameObject.Find("e1");
                StartCoroutine(TranquiEffect(enemigo));
            }
            if (GameController.t2)
            {
                enemigo = GameObject.Find("e2");
                StartCoroutine(TranquiEffect(enemigo));
            }
            if (GameController.t3)
            {
                enemigo = GameObject.Find("e3");
                StartCoroutine(TranquiEffect(enemigo));
            }
            if (GameController.t4)
            {
                enemigo = GameObject.Find("e4");
                StartCoroutine(TranquiEffect(enemigo));
            }
            if (GameController.t5)
            {
                enemigo = GameObject.Find("e5");
                StartCoroutine(TranquiEffect(enemigo));
            }
            if (GameController.t6)
            {
                enemigo = GameObject.Find("e6");
                StartCoroutine(TranquiEffect(enemigo));
            }
            if (GameController.t7)
            {
                enemigo = GameObject.Find("e7");
                StartCoroutine(TranquiEffect(enemigo));
            }

            if (GameController.b1)
            {
                Destroy(GameObject.Find("b1"));
            }
            if (GameController.b2)
            {
                Destroy(GameObject.Find("b2"));
            }
            if (GameController.b3)
            {
                Destroy(GameObject.Find("b3"));
            }
            if (GameController.b4)
            {
                Destroy(GameObject.Find("b4"));
            }
            if (GameController.b5)
            {
                Destroy(GameObject.Find("b5"));
            }

            inicia = false;
        }        
    }
    public IEnumerator NormalEffect(GameObject enemy)
    {
        Color deafault = enemy.GetComponent<SpriteRenderer>().color;
        efecT = true;
        effecting = true;
        
        enemy.GetComponent<EnemyMove>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        enemy.GetComponent<BoxCollider2D>().enabled = false;
        enemy.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator TranquiEffect(GameObject enemy)
    {
        Debug.Log("Desactivaaaaaaaaaaaaaando");
        efecT = true;
        effecting = true;
        enemy.GetComponent<SpriteRenderer>().color = Color.red;
        enemy.GetComponent<EnemyMove>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        enemy.GetComponent<BoxCollider2D>().enabled = false;
        enemy.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
    }
}
