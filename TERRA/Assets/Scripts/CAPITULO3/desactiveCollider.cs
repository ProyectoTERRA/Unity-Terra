using System.Collections;
using UnityEngine;

public class desactiveCollider : MonoBehaviour
{
    Collider2D collider;
    public GameObject desactive;
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        eliminarEnemyesC3.guardias = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 1)
        {
            StartCoroutine(enableCollider());
        }
        if (contador == 0)
        {
            StartCoroutine(falseCollider());
        }
    }
    IEnumerator enableCollider()
    {
        yield return new WaitForSeconds(5);
        collider.enabled = true;
        desactive.SetActive(false);
        contador = 0;
        Debug.Log("TRUE");
    }
    IEnumerator falseCollider()
    {
        yield return new WaitForSeconds(5);
        collider.enabled = false;
        desactive.SetActive(true);
        contador = 1;
        Debug.Log("FALSE");
    }
}
