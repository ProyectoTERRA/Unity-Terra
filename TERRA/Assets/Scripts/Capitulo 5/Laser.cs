using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private SpriteRenderer Beam;
    private BoxCollider2D Burn;
    // Start is called before the first frame update
    void Start()
    {
        Beam = GetComponent<SpriteRenderer>();
        Burn = GetComponent<BoxCollider2D>();
        StartCoroutine(Active());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {


            col.SendMessage("BiriBiriBanBan", transform.position.x);


        }
    }
    IEnumerator Active()
    {
        float rWait = Random.Range(1f, 5f);
        Beam.enabled = false;
        Burn.enabled = false;
        yield return new WaitForSeconds(rWait);
        Beam.enabled = true;
        Burn.enabled = true;
        yield return new WaitForSeconds(2f);

        StartCoroutine(Active());

    }
}
