using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private List<GridPosition> whitePositions;
    [SerializeField] private List<GridPosition> blackPositions;

    public List<GridPosition> GetWhitePositions() => whitePositions;
}
