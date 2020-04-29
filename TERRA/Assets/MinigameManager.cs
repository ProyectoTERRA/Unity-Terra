using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    int N1, N2, N3, N4;
    int C1, C2, C3, C4;
    public SpriteRenderer col1, col2, col3, col4;
    public GameObject D1, D2, D3, D4;
    public Sprite S1, S2, S3, S4, S5, S6, S7, S8, S9, S0;
    Color Cafe = new Color(0.6039216f, 0.2117647f, 0, 1);
    Color Naranja = new Color(0.9529412f, 0.6117647f, 0.07058824f, 1);
    Color Morado = new Color(0.5333334f, 0.3058824f, 0.627451f, 1);

    // Start is called before the first frame update
    void Start()
    {
        /*
        #region RANDOM
        N1 = Random.Range(0, 10);
        N2 = Random.Range(0, 10);
        N3 = Random.Range(0, 10);
        N4 = Random.Range(0, 10);

        C1 = Random.Range(0, 10);
        C2 = Random.Range(0, 10);
        C3 = Random.Range(0, 10);
        C4 = Random.Range(0, 10);
        #endregion
        */
    }

    // Update is called once per frame




    void Update()
    {
        N1 = Random.Range(0, 10);
        N2 = Random.Range(0, 10);
        N3 = Random.Range(0, 10);
        N4 = Random.Range(0, 10);

        C1 = Random.Range(0, 10);
        C2 = Random.Range(0, 10);
        C3 = Random.Range(0, 10);
        C4 = Random.Range(0, 10);

        #region Colores
        if (C1 == 0 || C2 == 0 || C3 == 0 || C4 == 0)
        {
            col1.color = Color.black;
        }
        if (C1 == 1 || C2 == 1 || C3 == 1 || C4 == 1)
        {
            col1.color = Cafe;
        }
        if (C1 == 2 || C2 == 2 || C3 == 2 || C4 == 2)
        {
            col1.color = Color.red;
        }
        if (C1 == 3 || C2 == 3 || C3 == 3 || C4 == 3)
        {
            col1.color = Naranja;
        }
        if (C1 == 4 || C2 == 4 || C3 == 4 || C4 == 4)
        {
            col1.color = Color.yellow;
        }
        if (C1 == 5 || C2 == 5 || C3 == 5 || C4 == 5)
        {
            col1.color = Color.green;
        }
        if (C1 == 6 || C2 == 6 || C3 == 6 || C4 == 6)
        {
            col1.color = Color.blue;
        }
        if (C1 == 7 || C2 == 7 || C3 == 7 || C4 == 7)
        {
            col1.color = Morado;
        }
        if (C1 == 8 || C2 == 8 || C3 == 8 || C4 == 8)
        {
            col1.color = Color.gray;
        }
        if (C1 == 9 || C2 == 9 || C3 == 9 || C4 == 9)
        {
            col1.color = Color.white;
        }
        #endregion

        #region Numeros
        if (N1 == 0 || N2 == 0 || N3 == 0 || N4 == 0 )
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S0;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S0;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S0;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S0;
            
        }
        if (N1 == 1 || N2 == 1 || N3 == 1 || N4 == 1)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
           
        }
        if (N1 == 2 || N2 == 2 || N3 == 2 || N4 == 2)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
            
        }
        if (N1 == 3 || N2 == 3 || N3 == 3 || N4 == 3)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
          

        }
        if (N1 == 4 || N2 == 4 || N3 == 4 || N4 == 4 )
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
            
        }
        if (N1 == 5 || N2 == 5 || N3 == 5 || N4 == 5)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
            
        }
        if (N1 == 6 || N2 == 6 || N3 == 6 || N4 == 6)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
          
        }
        if (N1 == 7 || N2 == 7 || N3 == 7 || N4 == 7 )
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
            
        }
        if (N1 == 8 || N2 == 8 || N3 == 8 || N4 == 8)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
          
        }
        if (N1 == 9 || N2 == 9 || N3 == 9 || N4 == 9)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S9;
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S9;
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S9;
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S9;
        }
        #endregion


    }
}
