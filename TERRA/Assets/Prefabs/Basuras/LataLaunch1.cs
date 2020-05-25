using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataLaunch1 : MonoBehaviour
{
    private Rigidbody2D rbd2;
    public float JumpPower = 100.0f;
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        rbd2.AddForce(Vector2.left * JumpPower, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10f);
    }
}
