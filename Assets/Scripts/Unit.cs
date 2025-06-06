using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected void generateName(Color unitColor)
    {
        this.name = $"Unit_{unitColor}";
    }
}
