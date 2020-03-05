using System.Collections;
using UnityEngine;

public class MDSL : MonoBehaviour
{
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
            GetComponent<KMDSL>().enabled = false;
            StartCoroutine(lib());
            target.position = (target.position == start) ? end : start;
            action = !action;
        }
    }

    IEnumerator lib()
    {

        float rWait = Random.Range(2, 5);
        if (action)
        {
            yield return new WaitForSeconds(rWait);
        }

        else if (!action)
        {
            yield return new WaitForSeconds(2f);
        }

        GetComponent<KAKA>().enabled = true;
    }


}
