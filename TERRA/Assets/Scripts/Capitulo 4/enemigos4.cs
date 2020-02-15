using UnityEngine;

public class enemigos4 : MonoBehaviour
{
    public static int guardias = 0;
    public GameObject puerta;
    void Update()
    {
        if (guardias == 7)
        {
            Debug.Log(guardias);
            puerta.SetActive(true);
        }
    }
}
