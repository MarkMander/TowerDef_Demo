using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.InputSystem;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance; 
    public GridManager GridManager;
    public Dictionary<Vector2, Tile> tileDict = new Dictionary<Vector2, Tile>();
    public Dictionary<Vector2, Unit> unitDict = new Dictionary<Vector2, Unit>();
    private Unit activeObject;
    public Unit unit1;
    public Unit unit2;
    public Unit unit3;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        tileDict = GridManager.GenerateGrid();

        activeObject = unit1;
    }

    void OnCycleUnit1()
    {
        activeObject = unit1;
        Debug.Log("Unit1 is active unit");
    }
    void OnCycleUnit2()
    {
        activeObject = unit2;
        Debug.Log("Unit2 is active unit");
    }
    void OnCycleUnit3()
    {
        activeObject = unit3;
        Debug.Log("Unit3 is active unit");
    }

    public void SpwnUnit(Vector2 tilePos)
    {
        var unit = Instantiate(activeObject, new Vector3(tilePos.x, tilePos.y, 0), Quaternion.identity);
        unitDict.Add(tilePos, unit);
        Debug.Log($"{unit.name} spawned");
    }

    public Unit GetUnit(Vector2 tilePos)
    {
        return unitDict[tilePos];
    }

    public void DestroyUnit(Vector2 tilePos)
    {
        Debug.Log($"unit destroyed"); 
        Destroy(unitDict[tilePos].gameObject);
        unitDict.Remove(tilePos);
        
    }
}
