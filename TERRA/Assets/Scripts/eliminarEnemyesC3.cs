using UnityEngine;

public class eliminarEnemyesC3 : MonoBehaviour
{
    public static int guardias = 0;
    public GameObject puerta;
    private void Start()
    {
        guardias = 0;

        Debug.Log("Eliminar enemigos " + guardias);
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
