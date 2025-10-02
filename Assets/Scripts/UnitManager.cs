using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance; 

    private GridManager gridManager;
    public Dictionary<Vector2, Tile> tileDict = new Dictionary<Vector2, Tile>();
    public Dictionary<Vector2, Unit> unitDict = new Dictionary<Vector2, Unit>();
    private Unit activeObject;
    public Unit unit1;
    public Unit unit2;
    public Unit unit3;
    public Transform[] path;
    private EnemySpwn enemySpwn;
    private Base bse;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        enemySpwn = GameObject.FindGameObjectWithTag("EnemySpwn").GetComponent<EnemySpwn>();
        gridManager = GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>();
        bse = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();

        tileDict = gridManager.GenerateGrid();
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

    public void DmgBase(float dmg)
    {
        bse.TakeDmg(dmg);
    }
}
