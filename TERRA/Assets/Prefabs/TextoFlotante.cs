using UnityEngine;

public class TextoFlotante : MonoBehaviour
{
    public float TiempoVida = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TiempoVida -= Time.deltaTime;
        if (TiempoVida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
