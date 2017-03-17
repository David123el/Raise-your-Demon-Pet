using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerObstacle : MonoBehaviour, IObstacle, IOnTouchEvent
{
    [SerializeField]
    private ParticleSystem particle;
    private float currentTime;
    [SerializeField]
    private float deltaTime;

    public ThrowerObstacle(ParticleSystem particle, float currentTime, float deltaTime)
    {
        this.DeltaTime = deltaTime;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public Manual Manual
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public ParticleSystem Particle
    {
        get
        {
            return particle;
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

    public void ActivateObstacle()
    {
        throw new NotImplementedException();
    }

    public void OnTouch()
    {
        throw new NotImplementedException();
    }
}
