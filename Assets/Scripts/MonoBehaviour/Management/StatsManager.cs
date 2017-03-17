using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int hunger;
    [SerializeField]
    private int sanity;
    [SerializeField]
    private Transform healthBar;
    [SerializeField]
    private Transform hungerBar;
    [SerializeField]
    private Transform sanityBar;
    [SerializeField]
    private PetManager petManager;

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

    public Transform HealthBar
    {
        get
        {
            return healthBar;
        }

        set
        {
            healthBar = value;
        }
    }

    public Transform HungerBar
    {
        get
        {
            return hungerBar;
        }

        set
        {
            hungerBar = value;
        }
    }

    public Transform SanityBar
    {
        get
        {
            return sanityBar;
        }

        set
        {
            sanityBar = value;
        }
    }

    public PetManager PetManager
    {
        get
        {
            return petManager;
        }

        set
        {
            petManager = value;
        }
    }

    public StatsManager(int health, int hunger, int sanity, Transform healthBar, Transform hungerBar, Transform sanityBar, PetManager petManager)
    {
        this.Health = health;
        this.Hunger = hunger;
        this.Sanity = sanity;
        this.HealthBar = healthBar;
        this.HungerBar = hungerBar;
        this.SanityBar = sanityBar;
        this.PetManager = petManager;
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    //change pet’s sprite when needed
    public void UpdateStats(int health, int hunger, int sanity)
    {

    }
}
