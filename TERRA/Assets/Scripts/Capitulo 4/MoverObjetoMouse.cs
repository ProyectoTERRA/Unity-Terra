using UnityEngine;
using UnityEngine.EventSystems;

public class MoverObjetoMouse : MonoBehaviour, IDragHandler
{
    //Se ejecuta repetidamente mientras se esté arrastrando
    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
        Debug.Log("Está siendo arrastrado");
    }

}
