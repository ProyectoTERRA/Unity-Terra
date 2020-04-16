using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerConductos : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject Key_Activator;

    [SerializeField] private GameObject Slider;
    [SerializeField] private GameObject TramplillaF;
    [SerializeField] private GameObject list;
    public Slider ActS;
    private bool Sec2;
    bool flag;

    // Start is called before the first frame update
    void Start()
    {
        Heart_Bar.Phearts = 6;
        flag = true;
 
        GetComponent<SliderConductos>().enabled = false;
        ActS.enabled = false;
        Slider.SetActive(false);
        Sec2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SliderConductos.Target)
        {
            Destroy(TramplillaF);
            GetComponent<PlayerController>().enabled = true ;

            if (flag)
            {
                GameObject go = GameObject.Find("InvFunc");
                radial radial = go.GetComponent<radial>();
                radial.especiales[2]--;
                GameController.ganzua--;
                string normal = "ganzua";
                if (radial.especiales[2] <= 0) list.SendMessage("remove", normal);
                flag = false;
            }

        }


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tran")//compara si hizo la colision con el objeto correcto
        {
            
            camera.transform.position = new Vector3(15f, -8f, -10.0f);
            Sec2 = true;

        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Accionador" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_2")//compara si hizo la colision con el objeto correcto
        {
            GetComponent<SliderConductos>().enabled = true;
            GetComponent<PlayerController>().enabled = false;
            ActS.enabled = true;
            Slider.SetActive(true);

            Key_Activator.SetActive(false);

        }
        if (collision.gameObject.name == "Die")//compara si hizo la colision con el objeto correcto
        {

            Debug.Log("Die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }
    }
}
