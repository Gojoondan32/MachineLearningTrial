
public enum TypeOfPiece
{
    pawn,
    knight,
    bishop,
    rook,
    queen,
    king
}

[System.Serializable]
public struct PieceData{
     public TypeOfPiece typeOfPiece;
     
}
