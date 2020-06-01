using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//compara si hizo la colision con el objeto correcto
        {
            Minijuego_1.start = false;
            Minijuego_1.win = false;


            collision.SendMessage("BiriBiriBanBan", transform.position.x);
        }
    }

}
