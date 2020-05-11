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
    void Start()
    {
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
        StartCoroutine(Active());
        do
        {
            moverse -= Time.deltaTime;

            if (FlagMove == true)
            {
                
                Debug.Log("HACIA ABAJO!");
                yield return new WaitForSeconds(5f);
            }
        } while (moverse > 0);

    }
}
