using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite vida20, vida19, vida18, vida17, vida16, vida15, vida14, vida13, vida12, vida11;
    public Sprite vida10, vida9, vida8, vida7, vida6, vida5, vida4, vida3, vida2, vida1, vida0;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = vida20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
