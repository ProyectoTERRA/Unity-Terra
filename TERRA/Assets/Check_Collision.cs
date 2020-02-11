using UnityEngine;

public class Check_Collision : MonoBehaviour
{
    private float OrigenOffset = 0.5f;
    public float raycastMaxDistance = 5.0f;
    // Start is called before the first frame update

    private RaycastHit2D ChecarRaycast(Vector2 direction)
    {
        float direccionOrigenOffset = OrigenOffset * (direction.y > 0 ? 1 : -1);
        Vector2 PosicionInicial = new Vector2(transform.position.x + direccionOrigenOffset, transform.position.y);

        Debug.DrawRay(PosicionInicial, direction, Color.red);
        return Physics2D.Raycast(PosicionInicial, direction, raycastMaxDistance);
    }

    private bool RaycastCheckUpdate()
    {
        Vector2 direction = new Vector2(0, 1);

        RaycastHit2D hit = ChecarRaycast(direction);
        if (hit.collider)
        {
            Debug.Log("Choco con el Objeto " + hit.collider.name);
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }
}
