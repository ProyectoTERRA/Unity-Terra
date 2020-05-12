using UnityEngine;

public class eliminarEnemyesC3 : MonoBehaviour
{
    public static int guardias;
    public GameObject puerta;

    public void Start()
    {
        guardias = 0;
    }
    void Update()
    {
        if (guardias == 7)
        {
            Debug.Log(guardias);
            puerta.SetActive(true);
        }
    }
}
