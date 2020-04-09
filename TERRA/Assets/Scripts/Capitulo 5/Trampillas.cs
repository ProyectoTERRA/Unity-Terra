using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampillas : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer OnTrap;
    private BoxCollider2D Bye;
    private bool Active;
    void Start()
    {
        Active = false;
        OnTrap = GetComponent<SpriteRenderer>();
        Bye = GetComponent<BoxCollider2D>();
        StartCoroutine(Trap());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Active = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Active = false;
        }
    }
    IEnumerator Trap()
    {
        float rWait = Random.Range(1f, 5f);

        yield return new WaitForSeconds(rWait);
        OnTrap.enabled = false;
        Bye.enabled = false;
        rWait = Random.Range(1f, 5f);
        yield return new WaitForSeconds(1f);
        if (!Active)
        {
            OnTrap.enabled = true;
            Bye.enabled = true;

        }
        
        StartCoroutine(Trap());

    }
}
