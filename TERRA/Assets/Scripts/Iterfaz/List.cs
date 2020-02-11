using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    public Sprite esf_N;
    public Sprite esf_P;
    public Sprite esf_D;
    public Sprite esf_T;
    public Sprite esf_H;

    List<string> hrr;
    public int index;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        hrr = new List<string>();
        hrr.Add("esf_N");
        hrr.Add("esf_P");
        hrr.Add("esf_D");
        hrr.Add("esf_T");
        hrr.Add("esf_H");

        PlayerController.Equip = hrr[0];
        Debug.Log(PlayerController.Equip);

        GetComponent<SpriteRenderer>().sprite = Resources.Load("Esferas_0", typeof(Sprite)) as Sprite;

    }

    // Update is called once per frame
    void Update()
    {
        i = hrr.Count;
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (index >= 0 && index <= i)
            {
                index++;
                if (index >= i) index = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.C))
        {

            if (index >= 0 && index <= i)
            {
                if (index <= 0) index = i;
                index--;

            }


        }


        PlayerController.Equip = hrr[index];


    }
}

public class herramiemtas
{
    string nombre;
    Sprite img;
}
