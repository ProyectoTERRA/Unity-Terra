using System.Collections;
using UnityEngine;

public class MDSL : MonoBehaviour
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


            col.SendMessage("RATAKnockBack", transform.position.x);


        }
    }
    IEnumerator Active()
    {
        float rWait = 6f;
        Beam.enabled = false;
        Burn.enabled = false;
        yield return new WaitForSeconds(rWait);
        Beam.enabled = true;
        Burn.enabled = true;
        yield return new WaitForSeconds(3f);

        StartCoroutine(Active());

    }

}
