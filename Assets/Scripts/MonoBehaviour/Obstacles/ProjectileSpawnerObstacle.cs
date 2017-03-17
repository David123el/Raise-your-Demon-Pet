using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerObstacle : MonoBehaviour, IObstacle, IOnTouchEvent
{
    [SerializeField]
    private Vector3 projectileSpawnPoint;
    [SerializeField]
    private Vector3 projectileDirection;
    [SerializeField]
    private float rateOfFire;

    public ProjectileSpawnerObstacle(Vector3 projectileSpawnPoint, Vector3 projectileDirection, float rateOfFire)
    {
        this.ProjectileSpawnPoint = projectileSpawnPoint;
        this.ProjectileDirection = projectileDirection;
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

    public Vector3 ProjectileSpawnPoint
    {
        get
        {
            return projectileSpawnPoint;
        }

        set
        {
            projectileSpawnPoint = value;
        }
    }

    public Vector3 ProjectileDirection
    {
        get
        {
            return projectileDirection;
        }

        set
        {
            projectileDirection = value;
        }
    }

    public float RateOfFire
    {
        get
        {
            return rateOfFire;
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
