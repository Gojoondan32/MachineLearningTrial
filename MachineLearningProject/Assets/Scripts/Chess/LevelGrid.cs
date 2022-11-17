using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance {get; private set;}
    [SerializeField] private Transform gridDebugObject;
    [SerializeField] private Transform piecePrefab;

    [SerializeField] private BoardManager boardManager;
    private GridSystem gridSystem;

    private void Awake() {
        if(Instance == null)
            Instance = this;
        else   
            Destroy(gameObject);


        gridSystem = new GridSystem(8, 8, 2f);
        gridSystem.CreateDebugObjects(gridDebugObject, piecePrefab);

        foreach(GridPosition piecePositions in boardManager.GetWhitePositions()){
            Instantiate(piecePrefab, GetWorldPosition(piecePositions), Quaternion.identity);
        }
    }

    public void AddPieceAtGridPosition(GridPosition gridPosition, Piece piece){
        //
        gridSystem.GetGridObject(gridPosition).AddPiece(piece);
    }

    public Piece GetPieceAtGridPosition(GridPosition gridPosition){
        return gridSystem.GetGridObject(gridPosition).GetPiece();
    }

    public void RemovePieceAtGridPosition(GridPosition gridPosition, Piece piece){
        gridSystem.GetGridObject(gridPosition).RemovePiece();
    }

    public void UnitMovedGridPosition(Piece piece, GridPosition fromGridPosition, GridPosition toGridPosition){
        RemovePieceAtGridPosition(fromGridPosition, piece);
        AddPieceAtGridPosition(toGridPosition, piece);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public bool HasAnyUnitOnGridPosition(GridPosition gridPosition){
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.HasAnyPiece();
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);

    public int GetWidth() => gridSystem.GetWidth();
    public int GetHeight() => gridSystem.GetHeight();
}
