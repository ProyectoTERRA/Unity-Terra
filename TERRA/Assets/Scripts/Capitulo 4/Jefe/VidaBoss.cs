using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite vida20, vida19, vida18, vida17, vida16, vida15, vida14, vida13, vida12, vida11;
    public Sprite vida10, vida9, vida8, vida7, vida6, vida5, vida4, vida3, vida2, vida1, vida0;

    public int hearts;

    

    public static bool effecting;
    private bool efecT;
    public GameObject bossLive;
    int x;
    void Start()
    {
        x = 0;
        effecting = false;
        efecT = false;
        hearts = 20;
        bossLive.GetComponent<SpriteRenderer>().sprite = vida20;
    }

    // Update is called once per frame
    void Update()
    {

        if (hearts == 19)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida19;
        }
        if (hearts == 18)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida18;
        }
        if (hearts == 17)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida17;
        }
        if (hearts == 16)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida16;
        }
        if (hearts == 15)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida15;
        }
        if (hearts == 14)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida14;
        }
        if (hearts == 13)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida13;
        }
        if (hearts == 12)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida12;
        }
        if (hearts == 11)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida11;
        }
        if (hearts == 10)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida10;
        }
        if (hearts == 9)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida9;
        }
        if (hearts == 8)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida8;
        }
        if (hearts == 7)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida7;
        }
        if (hearts == 6)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida6;
        }
        if (hearts == 5)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida5;
        }
        if (hearts == 4)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida4;
        }
        if (hearts == 3)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida3;
        }
        if (hearts == 2)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida2;
        }
        if (hearts == 1)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida1;
        }
        if(hearts == 0)
        {
            bossLive.GetComponent<SpriteRenderer>().sprite = vida0;
            if (x == 0)
            {
                Destroy(gameObject, 2f);
                x++;
                SceneManager.LoadScene("Celdas");
            }            
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Normal")
        {
            Debug.Log("Me diooooooooo normal");
            StartCoroutine(NormalEffect());
        }
        if (col.gameObject.tag == "Paraliz")
        {
            Debug.Log("Me diooooooooo paraliz");
            StartCoroutine(ParalizEffect());
        }
    }
    public IEnumerator NormalEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        efecT = true;
        effecting = true;
        GetComponent<Comportamiento>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        hearts--;
        yield return new WaitForSeconds(2f);

        efecT = false;
        effecting = false;
        GetComponent<Comportamiento>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = deafault;
    }
    public IEnumerator ParalizEffect()
    {
        Color deafault = GetComponent<SpriteRenderer>().color;
        effecting = true;
        efecT = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        GetComponent<Comportamiento>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(5f);

        GetComponent<SpriteRenderer>().color = deafault;
        GetComponent<Comportamiento>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        efecT = false;
        effecting = false;
    }

}
