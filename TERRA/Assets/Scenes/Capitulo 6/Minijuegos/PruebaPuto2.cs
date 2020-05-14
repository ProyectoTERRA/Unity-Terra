using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PruebaPuto2 : MonoBehaviour
{

    [SerializeField] private GameObject View;
    [SerializeField] private GameObject Cont;

    private MiniPuto2 MIN;
    bool put;
    // Start is called before the first frame update
    void Start()
    {
        MIN = Cont.GetComponent<MiniPuto2>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MiniPuto2.enable);
        if (MiniPuto2.enable)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (put)
        {
            StartCoroutine(MIN.Renabled());
            View.SetActive(true);
            put = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && MiniPuto2.enable && !MiniPuto2.start1 && !MiniPuto2.active && Input.GetKeyDown(KeyCode.Return) && !MiniPuto2.c3)
        {
            put = true;
        }
    }
}
