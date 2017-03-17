using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BoardItem : MonoBehaviour, IBoardItem
{
    [SerializeField] BoardManager gameBoard;
    [SerializeField] bool isDraggable;
    [SerializeField] Int2 size;
    [SerializeField] GameObject item;
    [SerializeField] int value;
    [SerializeField] float increasedPopulationPerSec;
    [SerializeField] float increasedCoinsPerSec;

    bool isOnBoard;
    [SerializeField] Int2 positionInArray;
    [SerializeField] Vector3 positionInWorld;



    public BoardManager GameBoard
    {
        get
        {
            return gameBoard;
        }

        set
        {
            gameBoard = value;
        }
    }

    public bool IsDraggable
    {
        get
        {
            return isDraggable;
        }

        set
        {
            isDraggable = value;
        }
    }

    public bool IsOnboard
    {
        get
        {
            return isOnBoard;
        }
    }

    public GameObject Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }

    public Int2 PositionInArray
    {
        get
        {
            return positionInArray;
        }

        set
        {
            positionInArray = value;
        }
    }

    public Vector3 PositionInWorld
    {
        get
        {
            return positionInWorld;
        }

        set
        {
            positionInWorld = value;
        }
    }

    public Int2 Size
    {
        get
        {
            return size;
        }

        set
        {
            size = value;
        }
    }

    public int Value
    {
        get
        {
            return value;
        }

        set
        {
            Value = value;
        }
    }

    public float IncreasedPopulationPerSec
    {
        get
        {
            return increasedPopulationPerSec;
        }

        set
        {
            increasedPopulationPerSec = value;
        }
    }

    public float IncreasedCoinsPerSec
    {
        get
        {
            return increasedCoinsPerSec;
        }

        set
        {
            increasedCoinsPerSec = value;
        }
    }



    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Initialize(Int2 posInArray, BoardManager board)
    {
        throw new NotImplementedException();
    }
}
