using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int hunger;
    [SerializeField]
    private int sanity;
    [SerializeField]
    private bool isPicked;

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public int Hunger
    {
        get
        {
            return hunger;
        }

        set
        {
            hunger = value;
        }
    }

    public int Sanity
    {
        get
        {
            return sanity;
        }

        set
        {
            sanity = value;
        }
    }

    public bool IsPicked
    {
        get
        {
            return isPicked;
        }

        set
        {
            isPicked = value;
        }
    }

    public Consumable(int health, int hunger, int sanity, bool isPicked)
    {
        this.Health = health;
        this.Hunger = hunger;
        this.Sanity = sanity;
        this.IsPicked = isPicked;
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
