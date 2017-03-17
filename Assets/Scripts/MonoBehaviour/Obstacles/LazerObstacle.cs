using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerObstacle : MonoBehaviour, IObstacle, IOnTouchEvent
{
    [SerializeField]
    private Sprite sprite;
    private float currentTime;
    [SerializeField]
    private float deltaTime;

    public LazerObstacle(Sprite sprite, float currentTime, float deltaTime)
    {
        this.sprite = sprite;
        this.currentTime = currentTime;
        this.deltaTime = deltaTime;
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
