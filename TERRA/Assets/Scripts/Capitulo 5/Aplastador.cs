using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplastador : MonoBehaviour
{
    [SerializeField] private GameObject YellowCard_OBJ;
    [SerializeField] private GameObject guard;
    // Start is called before the first frame update
    public Transform target;
    public float speed;
    private Vector3 start, end;
    private bool action;
    // Start is called before the first frame update
    void Start()
    {
        action = true;
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }

        if (transform.position == target.position)
        {
            GetComponent<Aplastador>().enabled = false;
            StartCoroutine(lib());
            target.position = (target.position == start) ? end : start;
            action = !action;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && PlayerController.movement)
        {
            Debug.Log("Ha hecho colision con el jugador");
            col.SendMessage("UnCorazon", transform.position.x);
        }
        if (col.gameObject.name == "APLR")
        {
            Destroy(guard);
            Destroy(col.gameObject);
            YellowCard_OBJ.SetActive(true);
        }
    }

    IEnumerator lib()
    {

        float rWait = Random.Range(2, 5);
        if (action)
        {
            
            yield return new WaitForSeconds(0.1f);
            GetComponent<BoxCollider2D>().enabled = false;
        }

        else if (!action)
        {
            
            yield return new WaitForSeconds(2f);
            GetComponent<BoxCollider2D>().enabled = true;
        }

        GetComponent<Aplastador>().enabled = true;
    }
}
