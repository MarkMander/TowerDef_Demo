using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    private float moveX;
    private float moveY;
    public float spd = 1;
    private Rigidbody2D rb;
    public float motionSmoothing = 0.3f;
    private Vector3 refVelocity = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMoveCamera(InputValue moveValue)
    {
        Vector2 moveVector = moveValue.Get<Vector2>();
        moveX = moveVector.x;
        moveY = moveVector.y;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, new Vector3(spd*moveX, spd*moveY, 0), ref refVelocity, motionSmoothing); 
    }


}
