using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionRandom : MonoBehaviour
{
    void Start()
    {
        float posX = Random.Range(-10.0f, 10.0f);
        transform.position = new Vector2(posX, -1.0f);
    }
}
