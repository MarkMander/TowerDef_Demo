using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance; 
    public GridManager GridManager;
    public Dictionary<Vector2, Tile> tileDict = new Dictionary<Vector2, Tile>();
    public Dictionary<Vector2, Unit> unitDict = new Dictionary<Vector2, Unit>();
    public Unit activeObject;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        tileDict = GridManager.GenerateGrid();
    }

    public void SpwnUnit(Vector2 tilePos)
    {
        var unit = Instantiate(activeObject, new Vector3(tilePos.x, tilePos.y, -5), Quaternion.identity);
        unitDict.Add(tilePos, unit);
        Debug.Log($"{activeObject.name} spawned");
    }

    public void DestroyUnit(Vector2 tilePos)
    {
        Destroy(unitDict[tilePos].gameObject);
        unitDict.Remove(tilePos);
        Debug.Log("unit destroyed");
    }
}
