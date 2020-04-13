using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderConductos : MonoBehaviour
{
    public static bool Target, active;
    private bool dir;
    [SerializeField] private GameObject Cavas;
    public Slider Bar;

    void Start()
    {
        dir = true;
        Target = false;
        active = true;
        Bar.value = 0;
        StartCoroutine(push());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            active = false;
            if(Bar.value >= 21 && Bar.value <= 25)
            {
                StartCoroutine(win());
            }
            else
            {
                StartCoroutine(reset());
            }
            
        }
        if (Bar.value == 0 && !Target)
        {
            dir = true;
        }
        else if (Bar.value == 50 && !Target)
        {
            dir = false;
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.name == "Exit")//compara si hizo la colision con el objeto correcto
        {

            Debug.Log("Salido");
            SceneManager.LoadScene("Sala de Servidores");



        }
    }

    public IEnumerator reset()
    {
        yield return new WaitForSeconds(3f);
        active = true;
        StartCoroutine(push());
    }
    public IEnumerator win()
    {
        yield return new WaitForSeconds(1.5f);
        Target = true;
        Cavas.SetActive(false);
        Bar.enabled = false;

    }
    public IEnumerator push()
    {
        if (dir)
        {
            Bar.value = Bar.value + 2;
        }
        else
        {
            Bar.value = Bar.value - 2;
        }
        yield return new WaitForSeconds(0.01f);

       

        if (active)
        {
            StartCoroutine(push());
        }


    }
}
