using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bufanda : MonoBehaviour
{
    public static bool hit, AttackSub;
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hit)
        {
           
            Debug.Log("Tazo de POOH");
            if (SubControler.SecondAttack)
            {
                hit = true;
                StartCoroutine(Ataque2());
                
            }
            else
            {
                hit = true;
                collision.SendMessage("TresCorazones", transform.position.x);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Ataque2()
    {
        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(0.5f);
        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        AttackSub = true;
        yield return new WaitForSeconds(0.3f);
        AttackSub = false;
    }
}
