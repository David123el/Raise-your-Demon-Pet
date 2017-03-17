using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private bool isMovable;
    [SerializeField]
    private bool isAffectedByGravity;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float distanceToDestruction;
    [SerializeField]
    private float timeBeforeDestruction;
    [SerializeField]
    private Sprite sprite;

    public bool IsMovable
    {
        get
        {
            return isMovable;
        }

        set
        {
            isMovable = value;
        }
    }

    public bool IsAffectedByGravity
    {
        get
        {
            return isAffectedByGravity;
        }

        set
        {
            isAffectedByGravity = value;
        }
    }

    public float Velocity
    {
        get
        {
            return velocity;
        }

        set
        {
            velocity = value;
        }
    }

    public float DistanceToDestruction
    {
        get
        {
            return distanceToDestruction;
        }

        set
        {
            distanceToDestruction = value;
        }
    }

    public float TimeBeforeDestruction
    {
        get
        {
            return timeBeforeDestruction;
        }

        set
        {
            timeBeforeDestruction = value;
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

    public Projectile(bool isMovable, bool isAffectedByGravity, float velocity, float distanceToDestruction, float timeBeforeDestruction, Sprite sprite)
    {
        this.IsMovable = isMovable;
        this.IsAffectedByGravity = isAffectedByGravity;
        this.Velocity = velocity;
        this.DistanceToDestruction = distanceToDestruction;
        this.TimeBeforeDestruction = timeBeforeDestruction;
        this.Sprite = sprite;
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void SelfDestruction()
    {

    }
}
