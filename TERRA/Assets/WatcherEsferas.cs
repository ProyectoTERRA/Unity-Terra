using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherEsferas : MonoBehaviour
{
    // Start is called before the first frame update

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

        if (gameObject.tag == "Watcher")
        {
            if (CDesactivadoras >= 3 && !efecT)
            {
                StartCoroutine(DesacEffect());
            }
        }

        if (gameObject.tag == "ROBOT")
        {
            if (CDesactivadoras >= 1 && !efecT)
            {
                Debug.Log("Puto");
                StartCoroutine(DesacEffect());
            }
        }


    }
    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Desac")
        {
            CDesactivadoras++;
            Destroy(collision.gameObject);
        }
    }


    public IEnumerator DesacEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        efecT = true;
        effecting = true;
        GetComponent<SpriteRenderer>().color = Color.blue;


        if (gameObject.tag == "Watcher")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Watcher>().enabled = false;
        }
        if (gameObject.tag == "ROBOT")
        {
            Turret.act = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().color = Color.grey;
    }
}
