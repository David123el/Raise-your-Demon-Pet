using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropableObstacle : MonoBehaviour, IObstacle, IPetGrumbleEvent, IOnTouchEvent
{
    [SerializeField]
    private bool isAttached;

    public Manual Manual
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public bool IsAttached
    {
        get
        {
            return isAttached;
        }

        set
        {
            isAttached = value;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void ActivateObstacle()
    {
        throw new NotImplementedException();
    }

    public void OnPetGrumble(Transform parent, Transform child)
    {
        throw new NotImplementedException();
    }

    public void OnTouch()
    {
        throw new NotImplementedException();
    }
}
