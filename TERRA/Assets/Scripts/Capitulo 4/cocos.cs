using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cocos : MonoBehaviour
{
    public GameObject coco1, coco2, coco3, coco4, coco5, coco6, coco7, coco8, coco9, coco10;
    float x;
    int entrar = 0, contador=0, total=0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(entrar == 0) { StartCoroutine(caida());  }
        if(entrar == 1) { StartCoroutine(caidaWait()); }
        if (total >= 30)
        {
            SceneManager.LoadScene("Mar");
        }
        Debug.Log("Total de cocos " + total);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "coco1") 
        {
            coco1.transform.position = new Vector2(-4, 5);
            coco1.SetActive(false);
            total++;
        }
        if(collision.name == "coco2")
        {
            coco2.transform.position = new Vector2(-4, 5);
            coco2.SetActive(false);
            total++;
        }
        if (collision.name == "coco3") 
        {
            coco3.transform.position = new Vector2(0, 5);
            coco3.SetActive(false);
            total++;
        }
        if (collision.name == "coco4")
        {
            coco4.transform.position = new Vector2(0, 5);
            coco4.SetActive(false);
            total++;
        }
        if (collision.name == "coco5") 
        {
            coco5.transform.position = new Vector2(4f, 5);
            coco5.SetActive(false);
            total++;
        }
        if (collision.name == "coco6")
        {
            coco6.transform.position = new Vector2(4f, 5);
            coco6.SetActive(false);
            total++;
        }
        if (collision.name == "coco7") 
        {
            coco7.transform.position = new Vector2(8f, 5);
            coco7.SetActive(false);
            total++;
        }
        if (collision.name == "coco8")
        {
            coco8.transform.position = new Vector2(8f, 5);
            coco8.SetActive(false);
            total++;
        }
        if (collision.name == "coco9") 
        {
            coco10.transform.position = new Vector2(12f, 5);
            coco10.SetActive(false);
            total++;
        }
        if (collision.name == "coco10")
        {
            coco10.transform.position = new Vector2(12f, 5);            
            coco10.SetActive(false);
            total++;
        }
    }
    IEnumerator caida()
    {
        yield return new WaitForSeconds(3);
        entrar = 1;
        if (contador == 1)
        {
            switch (x)
            {
                case 0:
                    coco1.SetActive(true);
                    break;

                case 1:
                    coco2.SetActive(true);
                    break;

                case 2:
                    coco3.SetActive(true);
                    break;

                case 3:
                    coco4.SetActive(true);
                    break;

                case 4:
                    coco5.SetActive(true);
                    break;

                case 5:
                    coco6.SetActive(true);
                    break;
                case 6:
                    coco7.SetActive(true);
                    break;
                case 7:
                    coco8.SetActive(true);
                    break;
                case 8:
                    Debug.Log("coco 9");
                    coco9.SetActive(true);
                    break;
                case 9:
                    coco10.SetActive(true);
                    break;
            }
        }
        contador = 2;        
    }
    IEnumerator caidaWait()
    {
        yield return new WaitForSeconds(3);
        x = Random.Range(0, 10);
        entrar = 0;
        contador = 1;
        coco1.SetActive(false);
    }
}
