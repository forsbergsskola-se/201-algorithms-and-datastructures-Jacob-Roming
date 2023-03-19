using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Cell
{
    public bool walkable;
    [HideInInspector] public bool visited;
    //Predecessor
    public float cost;

    public float[] costPerPlayer;
    [NonSerialized]public float currentCost = float.MaxValue;
    public State thisCellsState;
}


[CreateAssetMenu]
public class Grid : ScriptableObject
{
    public Cell[] Cells; // 50
    public int width;  // 5
    public int Height => Cells.Length / width;

    public Cell GetCell(int x, int y)
    {
        return Cells[x + y * width];
    }
    public bool IsCellWalkable(int x, int y) => GetCell(x,y).walkable;
    public bool IsCellWalkable(Vector2Int pos) => IsCellWalkable(pos.x, pos.y);
    
    public Cell GetCell(Vector2Int pos) => GetCell(pos.x, pos.y);

    public void OnEnable()
    {
        foreach (var cell in Cells)
        {
            cell.visited = false;
            //cell.cost = 1;

            cell.currentCost = float.MaxValue;
            cell.costPerPlayer = new float[4];
            for (int i = 0; i < cell.costPerPlayer.Length; i++)
            {
                cell.costPerPlayer[i] = float.MaxValue;
            }
        }
    }

    public void ResetCost()
    {
        foreach (var cell in Cells)
        {
            cell.costPerPlayer = new float[4];
            for (int i = 0; i < 4; i++)
            {
                cell.costPerPlayer[i] = float.MaxValue;
            }
        }
    }
}