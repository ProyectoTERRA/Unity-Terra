using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EsferaPesada : MonoBehaviour
{

        public Rigidbody2D projectile;

        void Update()
        {
            // Ctrl was pressed, launch a projectile
            if (Input.GetKeyDown(KeyCode.J))
            {
                // Instantiate the projectile at the position and rotation of this transform
                Rigidbody2D clone;
                clone = Instantiate(projectile, transform.position, transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.forward * 100);

                // Give the cloned object an initial velocity along the current
                // object's Z axis
            }
        }
    
}
