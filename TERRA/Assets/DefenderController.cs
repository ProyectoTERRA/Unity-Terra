using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject canon;
    private Transform target;

    static public bool act;
    public float speed;
    void Start()
    {
        act = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(Perseguir());

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

        IEnumerator Active()
    {
        Debug.Log("Iniciando disparos");
            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(6f);
            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(6f);
           Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(6f);
        StartCoroutine(Perseguir());
        yield return new WaitForSeconds(20f);
        StartCoroutine(Active());
    }
    IEnumerator Perseguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Debug.Log("Moviendose...");
        yield return new WaitForSeconds(10f);
        StartCoroutine(Active());
    }
}
