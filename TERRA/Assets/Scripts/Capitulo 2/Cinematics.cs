using UnityEngine;

public class Cinematics : MonoBehaviour
{
    private bool Agrandar = false;
    private Camera Cam;




    // Start is called before the first frame update
    void Start()
    {

        Cam = GetComponent<Camera>();
        Cam.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            Cam.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
