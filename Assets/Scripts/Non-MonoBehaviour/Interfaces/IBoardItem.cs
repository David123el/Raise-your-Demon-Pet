using UnityEngine;
using System.Collections;

public interface IBoardItem
{
    Int2 Size { get; set; }
    Int2 PositionInArray { get; set; }
    Vector3 PositionInWorld { get; set; }
    GameObject Item { get; set; }
    bool IsDraggable { get; set; }
    bool IsOnboard { get; }
    BoardManager GameBoard { get; set; }
    int Value { get; set; }
    float IncreasedPopulationPerSec { get; set; }
    float IncreasedCoinsPerSec { get; set; }

    void Initialize(Int2 posInArray, BoardManager GameBoard);
    void Dispose();
}
