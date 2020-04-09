using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConductos : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private bool Sec2;

    // Start is called before the first frame update
    void Start()
    {
        Sec2 = false;
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tran")//compara si hizo la colision con el objeto correcto
        {
            
            camera.transform.position = new Vector3(15f, -8f, -10.0f);
            Sec2 = true;

        }
    }
}
