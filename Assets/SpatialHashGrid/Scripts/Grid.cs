using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private readonly int _gridWidth;
    private readonly int _gridHeight;
    private readonly int _cellSize;

    private readonly List<ISpatialEntity>[] _cells;
   

    public Grid(int gridWidth, int gridHeight, int cellSize)
    {
        _gridHeight = gridHeight;
        _gridWidth = gridWidth;
        _cellSize = cellSize;

        _cells = new List<ISpatialEntity>[gridWidth * gridHeight];

        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i] = new List<ISpatialEntity>(64);
        }
    }


    public int GetCellIndex(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt(worldPos.x / _cellSize);
        int z = Mathf.FloorToInt(worldPos.z / _cellSize);    

        x = Mathf.Clamp(x, 0, _gridWidth - 1);
        z = Mathf.Clamp(z, 0, _gridHeight - 1);

        return x + (z * _gridWidth);
    }

    public void AddObjectToCell(int index, ISpatialEntity entity)
    {
        _cells[index].Add(entity);
    }

    public Vector3 GetCellCenter(int cellIndex)
    {
        int x = cellIndex % _gridWidth;
        int z = cellIndex / _gridWidth;
        return new Vector3(x * _cellSize + _cellSize / 2f, 0, z * _cellSize + _cellSize / 2f);
    }

    public void ClearCell(int cellIndex)
    {
        _cells[cellIndex].Clear();
    }

    public void ClearAllCells()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].Clear();
        }
    }

    public void MoveEntity(ISpatialEntity entity, Vector3 oldPos, Vector3 newPos)
    {
        int oldIndex = GetCellIndex(oldPos);
        int newIndex = GetCellIndex(newPos);

        if (oldIndex == newIndex) return;

        _cells[oldIndex].Remove(entity);
        _cells[newIndex].Add(entity);
    }

    public void GetNearbyEntities(Vector3 position, float radius, List<ISpatialEntity> result)
    {
        int radiusInCells = Mathf.CeilToInt(radius / _cellSize);

        int cordsX = Mathf.FloorToInt(position.x / _cellSize);
        int cordsZ = Mathf.FloorToInt(position.z / _cellSize);

        for (int z = cordsZ - radiusInCells; z <= cordsZ + radiusInCells; z++)
        {
            for (int x = cordsX - radiusInCells; x <= cordsX + radiusInCells; x++)
            {
                if (x < 0 || x >= _gridWidth || z < 0 || z >= _gridHeight) continue;
                int index = x + (z * _gridWidth);
                List<ISpatialEntity> cellEntities = _cells[index];
                for (int i = 0; i < cellEntities.Count; i++)
                {
                    result.Add(cellEntities[i]);
                }
            }
        }
    }


    public void GetNearbyEntitiesInCircle(Vector3 position, float radius, List<ISpatialEntity> result)
    {
        int radiusInCells = Mathf.CeilToInt(radius / _cellSize);
        int cordsX = Mathf.FloorToInt(position.x / _cellSize);
        int cordsZ = Mathf.FloorToInt(position.z / _cellSize);
        float sqrRadius = radius * radius;
        for (int z = cordsZ - radiusInCells; z <= cordsZ + radiusInCells; z++)
        {
            for (int x = cordsX - radiusInCells; x <= cordsX + radiusInCells; x++)
            {
                if (x < 0 || x >= _gridWidth || z < 0 || z >= _gridHeight) continue;
                int index = x + (z * _gridWidth);
                List<ISpatialEntity> cellEntities = _cells[index];
                for (int i = 0; i < cellEntities.Count; i++)
                {
                    if ((cellEntities[i].Position - position).sqrMagnitude <= sqrRadius)
                    {
                        result.Add(cellEntities[i]);
                    }
                }
            }
        }
    }
}
