using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct State
{
    public Vector2Int playerPosition;
    [SerializeField] private Grid m_grid;


    public Grid Grid => m_grid;
    
    bool PositionExists(Vector2Int newPosition)
    {
        return newPosition.x > -1 && newPosition.x < m_grid.width &&
               newPosition.y > -1 && newPosition.y < m_grid.Height;
    }
    
    bool PositionExistsAndIsWalkable(Vector2Int newPosition)
    {
        return PositionExists(newPosition) &&
               m_grid.IsCellWalkable(newPosition) == true;
    }

    
    public IEnumerable<State> GetSuccessors()
    {
        Vector2Int newPosition = playerPosition + Vector2Int.left;
        if (PositionExistsAndIsWalkable(newPosition))
        {
            yield return new State
            {
                playerPosition = newPosition,
                m_grid = m_grid
            };
        }
        newPosition = playerPosition + Vector2Int.right;
        if (PositionExistsAndIsWalkable(newPosition))
        {
            yield return new State
            {
                playerPosition = newPosition,
                m_grid = m_grid
            };
        }
        newPosition = playerPosition + Vector2Int.up;
        if (PositionExistsAndIsWalkable(newPosition))
        {
            yield return new State
            {
                playerPosition = newPosition,
                m_grid = m_grid
            };
        }
        newPosition = playerPosition + Vector2Int.down;
        if (PositionExistsAndIsWalkable(newPosition))
        {
            yield return new State
            {
                playerPosition = newPosition,
                m_grid = m_grid
            };
        }
    }
}