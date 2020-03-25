using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Minijuego_2 : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject bTN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
    }
    void OnMouseOver()
    {
        
    }
}
