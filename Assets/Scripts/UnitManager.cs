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

    public InputAction CycleUnit1;
    public InputAction CycleUnit2;
    public InputAction CycleUnit3;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        tileDict = GridManager.GenerateGrid();

        activeObject = unit1;

        CycleUnit1 = InputSystem.actions.FindAction("CycleUnit1");
        CycleUnit2 = InputSystem.actions.FindAction("CycleUnit2");
        CycleUnit3 = InputSystem.actions.FindAction("CycleUnit3");
    }

    private void Update()
    {
        checkUnitCycle();        
    }

    private void checkUnitCycle()
    {
        if (CycleUnit1.IsPressed())
        {
            activeObject = unit1;
            Debug.Log("Unit1 is active unit");
        }
        else if (CycleUnit2.IsPressed())
        {
            activeObject = unit2;
            Debug.Log("Unit2 is active unit");
        }
        else if (CycleUnit3.IsPressed())
        {
            activeObject = unit3;
            Debug.Log("Unit3 is active unit");
        }
    }

    public void SpwnUnit(Vector2 tilePos)
    {
        var unit = Instantiate(activeObject, new Vector3(tilePos.x, tilePos.y, -5), Quaternion.identity);
        unitDict.Add(tilePos, unit);
        Debug.Log($"{unit.name} spawned");
    }

    public void DestroyUnit(Vector2 tilePos)
    {
        Debug.Log($"unit destroyed, delt {unitDict[tilePos].dmg} damage"); 
        Destroy(unitDict[tilePos].gameObject);
        unitDict.Remove(tilePos);
        
    }
}
