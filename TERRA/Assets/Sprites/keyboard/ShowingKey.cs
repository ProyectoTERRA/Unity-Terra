using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingKey : MonoBehaviour
{
    [SerializeField] private GameObject Gspr;
    [SerializeField] private GameObject Gspr_Special;
    [SerializeField] private Sprite Spr;
    [SerializeField] private bool especiales;
    // Start is called before the first frame update
    void Start()
    {
        Gspr.GetComponent<SpriteRenderer>().sprite = Spr;
        Gspr.SetActive(false);
        Gspr_Special.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (especiales){
              Gspr_Special.SetActive(true);
            }
            Gspr.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            if (especiales)
            {
                Gspr_Special.SetActive(false);
            }
            Gspr.SetActive(false);
        }
    }
}
