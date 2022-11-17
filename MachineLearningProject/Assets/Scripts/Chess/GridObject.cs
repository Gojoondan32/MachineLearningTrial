using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    private GridSystem gridSystem;

    //This represents the index of that this grid object occupies in the 2D array on the grid system
    private GridPosition gridPosition;

    private Piece piece;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition){
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        piece = null;
    }

    
    public override string ToString()
    {
        /*
        string unitString = "";
        foreach(Piece unit in piece){
            unitString += unit + "\n";
        }
        */
        //return $"x: {gridPosition.x} z: {gridPosition.y} \n unit: {unitString} ";
        return $"x: {gridPosition.x} z: {gridPosition.y} ";
    }
    

    #region Assinging Units
    public void AddPiece(Piece piece) => this.piece = piece;
    public Piece GetPiece() => piece;
    public void RemovePiece() => piece = null;

    #endregion

    public bool HasAnyPiece(){
        return piece != null;
    }

}
