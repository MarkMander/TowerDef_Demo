using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance; 
    public GridManager GridManager;
    public Dictionary<Vector2, Tile> tileDict = new Dictionary<Vector2, Tile>();
    public Dictionary<Vector2, placedObject> unitDict = new Dictionary<Vector2, placedObject>();
    public placedObject activeObject;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        tileDict = GridManager.GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        PollTiles();
    }

    void PollTiles()
    {
        foreach (KeyValuePair<Vector2,Tile> entry in tileDict)
        {
            if (entry.Value.requestSpwn == true)
            {
                SpwnUnit(entry.Key);
                Debug.Log("Unit Spawned");
                entry.Value.requestSpwn = false;
            }
            if (entry.Value.requestDestroy == true)
            {
                Destroy(unitDict[entry.Key].gameObject);
                unitDict.Remove(entry.Key);
                entry.Value.requestDestroy = false;
            }
        }
    }

    void SpwnUnit(Vector2 tilePos)
    {
        var unit = Instantiate(activeObject, new Vector3(tilePos.x, tilePos.y, -5), Quaternion.identity);
        unitDict.Add(tilePos, unit);
    }
}
