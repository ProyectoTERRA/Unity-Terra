using System.Collections;
using UnityEngine;

public class Bombas : MonoBehaviour
{
    public GameObject c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20;
    int contador = 0, entrar = 0, x, y;
    // Start is called before the first frame update
    private void Update()
    {
        if (entrar == 0) { StartCoroutine(caida()); }
        if (entrar == 1) { StartCoroutine(caidaWait()); }
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
                    c1.SetActive(true);
                    break;

                case 1:
                    c2.SetActive(true);
                    break;

                case 2:
                    c3.SetActive(true);
                    break;

                case 3:
                    c4.SetActive(true);
                    break;

                case 4:
                    c5.SetActive(true);
                    break;

                case 5:
                    c6.SetActive(true);
                    break;
                case 6:
                    c7.SetActive(true);
                    break;
                case 7:
                    c8.SetActive(true);
                    break;
                case 8:
                    Debug.Log("coco 9");
                    c9.SetActive(true);
                    break;
                case 9:
                    c10.SetActive(true);
                    break;
                case 10:
                    c11.SetActive(true);
                    break;
                case 11:
                    c12.SetActive(true);
                    break;
                case 12:
                    c13.SetActive(true);
                    break;
                case 13:
                    c14.SetActive(true);
                    break;
                case 14:
                    c15.SetActive(true);
                    break;
                case 15:
                    c16.SetActive(true);
                    break;
                case 16:
                    c17.SetActive(true);
                    break;
                case 17:
                    c18.SetActive(true);
                    break;
                case 18:
                    c19.SetActive(true);
                    break;
                case 19:
                    c20.SetActive(true);
                    break;
            }
        }
        contador = 2;
    }
    IEnumerator caidaWait()
    {
        yield return new WaitForSeconds(3);
        x = Random.Range(0, 20);
        entrar = 0;
        contador = 1;
    }
}
