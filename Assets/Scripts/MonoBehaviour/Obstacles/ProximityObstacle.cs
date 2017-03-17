using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityObstacle : MonoBehaviour, IObstacle, IOnTouchEvent
{
    [SerializeField]
    private Sprite sprite;
    private float currentTime;
    [SerializeField]
    private float deltaTime;
    [SerializeField]
    private bool isActive;

    public ProximityObstacle(Sprite sprite, float currentTime, float deltaTime, bool isActive)
    {
        this.Sprite = sprite;
        this.DeltaTime = deltaTime;
        this.IsActive = isActive;
    }

    public Manual Manual
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }

        set
        {
            sprite = value;
        }
    }

    public float CurrentTime
    {
        get
        {
            return currentTime;
        }
    }

    public float DeltaTime
    {
        get
        {
            return deltaTime;
        }

        set
        {
            deltaTime = value;
        }
    }

    public bool IsActive
    {
        get
        {
            return isActive;
        }

        set
        {
            isActive = value;
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

    public void OnTouch()
    {
        throw new NotImplementedException();
    }
}
