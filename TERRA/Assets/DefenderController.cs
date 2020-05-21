using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject canon;
    GameObject Jugador;
    public Rigidbody2D RBD;
    public float moverse = 15f;
    public float speed;
    private Transform target;
    static public bool act;
    public bool FlagMove;
    public Animator anim;
    void Start()
    {
        anim.enabled = false;
        act = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        RBD = GetComponent<Rigidbody2D>();
        StartCoroutine(Perseguir());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

      transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("EnemyKnockBack", transform.position.x + 1);

        }
        if (col.gameObject.tag == "DEFEND")
        {
            anim.enabled = true;
            anim.SetTrigger("End");
            anim.SetTrigger("Adios");
            StartCoroutine(MuerteDestruccion());

        }
    }
    
    


    IEnumerator Active()
    {
        Debug.Log("Iniciando disparos");
            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(4f);
            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(4f);
           Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(4f);
        StartCoroutine(Perseguir());
        yield return new WaitForSeconds(20f);
        StartCoroutine(Active());
    }
    IEnumerator Perseguir()
    {
        yield return new WaitForSeconds(6f);
        FlagMove = true;
        do
        {
            moverse -= Time.deltaTime;

            if (FlagMove == true)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                Debug.Log("HACIA ABAJO!");
                yield return new WaitForSeconds(5f);
            }
        } while (moverse > 0);
        StartCoroutine(Active());

    }
    IEnumerator MuerteDestruccion()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
