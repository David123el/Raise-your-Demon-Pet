using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //might change that to classes instead of dictionary
    [SerializeField]
    private Dictionary<ParticleSystem, List<bool>> playerCustoms; //bool for unlocked and bool for equipped
    [SerializeField]
    private Dictionary<Sprite, List<bool>> petCustoms;

    public Dictionary<ParticleSystem, List<bool>> PlayerCustoms
    {
        get
        {
            return playerCustoms;
        }

        set
        {
            playerCustoms = value;
        }
    }

    public Dictionary<Sprite, List<bool>> PetCustoms
    {
        get
        {
            return petCustoms;
        }

        set
        {
            petCustoms = value;
        }
    }

    public GameManager(Dictionary<ParticleSystem, List<bool>> playerCustoms, Dictionary<Sprite, List<bool>> petCustoms, bool isTimeAttack)
    {
        this.PlayerCustoms = playerCustoms;
        this.PetCustoms = petCustoms;
    }

    void Awake ()
    {
        
    }

    void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    public void LoadLevelSelectionScreen()
    {

    }

    //loads a level first time by getting it's ID
    public void LoadLevel(LevelStatus levelStatus)
    {

    }

    public void ExitGame()
    {

    }

    public void EnterShop()
    {

    }

    public void LoadNextLevel()
    {

    }

    public void ReplayLevel()
    {

    }
}
