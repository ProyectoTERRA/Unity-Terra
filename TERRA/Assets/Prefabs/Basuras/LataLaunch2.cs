using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataLaunch2 : MonoBehaviour
{
    // Start is called before the first frame update
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
        Destroy(gameObject, 7f);
    }
}
