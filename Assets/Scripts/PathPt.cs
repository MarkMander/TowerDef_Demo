using UnityEngine;

public class PathPt : MonoBehaviour
{
    private SpriteRenderer pt;
    public bool pathDebugMode = false;
    void Start()
    {
        pt = GetComponent<SpriteRenderer>();
        pt.enabled = pathDebugMode;
    }
}
