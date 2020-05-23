using UnityEngine;

public class CameraFollow : MonoBehaviour


{
    public GameObject follow;
    public Vector2 minCamPos, maxCamPos;
    public Vector2 minCamSaved, maxCamSaved;
    public float smoothTime;

    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        minCamSaved = minCamPos;
        maxCamSaved = maxCamPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    

        float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x,
            ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y,
             ref velocity.y, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);

        if (Input.GetKey(KeyCode.W)) 
           {
                
            maxCamPos = maxCamPos + new Vector2(0, 3);
            transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY + 3, minCamPos.y, maxCamPos.y),
            transform.position.z);
            smoothTime = 0.01f;
        }
        else
        {
            maxCamPos = maxCamSaved;
            smoothTime = 0f;
        }
    }
}
