using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCalle : MonoBehaviour
{
    [SerializeField] private GameObject camera;



    public bool s1, s2;

    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        camera.transform.localScale = new Vector3(1f, 1f, 1f);

        transform.position = new Vector3(-7f, -.75f);


        s1 = true;
        s2 = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tran1" && s1)//compara si hizo la colision con el objeto correcto
        {


            s1 = false;
            s2 = true;
            camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);

        }

        if (collision.gameObject.name == "Tran2" && s2)//compara si hizo la colision con el objeto correcto
        {
            s1 = true;
            s2 = false;
            camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);
            
        }
    }
}
