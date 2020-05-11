using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject canon;
    private Animator Anim;

    static public bool act;
    private float timer;
    public float minTime;
    public float maxTime;

    private Transform playerPos;
    public float speed;
    void Start()
    {
        act = true;
        StartCoroutine(Perseguir());
        StartCoroutine(Active());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = 20f;

    }

    IEnumerator Active()
    {

            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
           Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
        StartCoroutine(Perseguir());
        yield return new WaitForSeconds(20f);
        StartCoroutine(Active());
    }
    IEnumerator Perseguir()
    {
        Vector2 target = new Vector2(playerPos.position.x, gameObject.transform.position.y);
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime);
        StartCoroutine(Active());
        yield return new WaitForSeconds(10f);
    }
}
