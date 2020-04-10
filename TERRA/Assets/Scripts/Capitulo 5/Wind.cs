using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private GameObject Drag;
    private SpriteRenderer wind;
    private Animator Anim;
    private bool Act;
    // Start is called before the first frame update
    void Start()
    {

        wind = GetComponent<SpriteRenderer>();
        
        Anim = GetComponent<Animator>();

        StartCoroutine(Active());

    }

    // Update is called once per frame
    void Update()
    {
        if (Act)
        {
            Drag.SetActive(true);
        }
        else
        {
            Drag.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {

    }


    IEnumerator Active()
    {
        Debug.Log(Act);
        Anim.Rebind();
        Anim.enabled = true;
        wind.enabled = true;

        Debug.Log(Act);
        Act = true;

        Anim.Play("Wind",-1,0f);


        yield return new WaitForSeconds(2f);
        Act = false;
        yield return new WaitForSeconds(2f);
        float rWait = Random.Range(1f, 5f);
        Anim.enabled = false;
        wind.enabled = false;
        yield return new WaitForSeconds(rWait);

        StartCoroutine(Active());


    }
   
}
