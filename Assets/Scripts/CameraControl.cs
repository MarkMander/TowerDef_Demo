using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    private float moveX;
    private float moveY;
    public float spd = 1;
    private Rigidbody2D rb;
    public float motionSmoothing = 0.3f;
    private Vector3 refVector = Vector3.zero;

    public float minZoom = 2f;
    public float maxZoom = 20f;
    public float zoomMult = 1f;
    private float zoom;
    public float zoomSmoothing = 0.3f;
    private float refFloat = 0;

    [SerializeField] private Camera cam;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = rb.GetComponent<Camera>();
        zoom = cam.orthographicSize;
    }

    void OnMoveCamera(InputValue moveValue)
    {
        Vector2 moveVector = moveValue.Get<Vector2>();
        moveX = moveVector.x;
        moveY = moveVector.y;
    }

    void OnZoom(InputValue zoomValue)
    {
        float scroll = zoomValue.Get<float>();
        zoom -= scroll * zoomMult;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, new Vector3(spd*moveX, spd*moveY, 0), ref refVector, motionSmoothing);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref refFloat, zoomSmoothing);
    }


}
